using Godot;
using System;
using System.Diagnostics.Contracts;

namespace TokenTaleTheElementalSaga;

[Tool]
[GlobalClass]
public abstract partial class Monster : Character3D
{
    [Export]
    public PackedScene ElementalTokenPackedScene { get; set; }
    [Export]
    public PackedScene CoinPackedScene { get; set; }
    [Export]
    public PackedScene HealDropPackedScene { get; set; }
    [Export]
    public EnemiesVisitor VisitorAbilityDispatch { get; set; }
    [Export]
    public NavigationRegion3D NavigationRegion3DStatic { get; set; }
    
    [Export]
    public Global.MonsterType
                  MonsterType
    {
        get;
        set;
    }
    [Signal]
    public delegate void DifficultyChangedEventHandler();
    public string Key { get; protected set; }
    public float CurrentDamage { get; protected set; }
    public float Damage { get; protected set; } = 1.0f;
    protected Godot.Collections.Dictionary<int, string> RatioRange = new();
    protected Godot.Collections.Dictionary<string, Global.Element> ElementalTokenElementDict = new();
    
    public abstract void Attack(MainCharacter targetMainCharacter);
    public abstract void AcceptVisitor(EnemiesVisitor visitor);
    public virtual void CreateAbility(string abilityName, MainCharacter targetMainCharacter)
    {
		Ability3D tempAbility = this
			.AbilityPackedScenes[abilityName]
			.Instantiate<Ability3D>();
		tempAbility.Attach(
			this.NavigationRegion3DStatic,
			this,
			NavigationRegion3DStatic.ToLocal(this.GlobalPosition),
			NavigationRegion3DStatic.ToLocal(targetMainCharacter.GlobalPosition));
	}
	public override float CalculateElementalDamage(Ability3D ability, Character3D targetCharacter)
	{
        float damage = 0;
        if (targetCharacter is not MainCharacter)
            return damage;
        damage = this.CurrentDamage * ability.DamageRatio;
        BaseDH elementalReactionDH = null;
        if (targetCharacter.ElementMark == Global.Element.None)
        {
			targetCharacter.ElementMark = ability.Element;
        }
        else
        {
            elementalReactionDH = new ElementalReactionDH(
                targetCharacter.ElementMark,
                ability.Element,
                false);
            targetCharacter.ElementMark = Global.Element.None;
        }
        if (elementalReactionDH != null)
            elementalReactionDH.ProcessDamage(ref damage);
        damage = (float)Math.Round(damage, 2);
        targetCharacter.StatusInfo.Items.Add(
            new StatusInfoItemElemental {Element = ability.Element, Thing = $"-{damage}" });
        return damage;
	}
	public override float CalculatePhysicsDamage(Character3D targetCharacter)
	{
		float damage = 0;
		if (targetCharacter is not MainCharacter)
			return damage;
        damage = this.CurrentDamage;
		damage = (float)Math.Round(damage, 2);
		targetCharacter.StatusInfo.Items.Add(
            new StatusInfoItemHurt { Thing = $"-{damage}" });
        return damage;
	}
	public void UpdateStats()
    {
        Record.MonsterInfo MonsterInfo = MonsterStats.GetInstance()
            .Monster[this.Key];
        Record.DifficultyScale Difficulty= GameManager.GetInstance()
            .MonsterManager
            .CurrentDifficulty;
        this.Damage = MonsterInfo.BaseDamage * Difficulty.MonsterBaseDamageRatio;
        this.MaxHealth = MonsterInfo.BaseMaxHealth * Difficulty.MonsterMaxHealthRatio;
        this.MaxSpeed = MonsterInfo.BaseMoveSpeed;
	}
	public override void _Ready()
	{
		base._Ready();
        //init ability resource
        VisitorAbilityDispatch.Init();
        this.AcceptVisitor(this.VisitorAbilityDispatch);
        //update stats base on difficulty
        this.DifficultyChanged += this.UpdateStats;
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.MaxSpeed;
		this.CurrentDamage = this.Damage;
        //setup for dropping
        this.SetupRatioRange();
        this.SetupElementalTokenElementDict();
	}
    protected virtual void SetupRatioRange()
    {
        RatioRange.Add(8, "fire");
		RatioRange.Add(16, "water");
		RatioRange.Add(24, "wind");
		RatioRange.Add(32, "ice");
		RatioRange.Add(40, "electric");
		RatioRange.Add(48, "earth");
		RatioRange.Add(56, "wood");
		RatioRange.Add(86, "heal");
	}
    protected void SetupElementalTokenElementDict()
    {
        ElementalTokenElementDict.Add("fire", Global.Element.Fire);
		ElementalTokenElementDict.Add("water", Global.Element.Water);
		ElementalTokenElementDict.Add("wind", Global.Element.Wind);
		ElementalTokenElementDict.Add("ice", Global.Element.Ice);
		ElementalTokenElementDict.Add("electric", Global.Element.Electric);
		ElementalTokenElementDict.Add("earth", Global.Element.Earth);
		ElementalTokenElementDict.Add("wood", Global.Element.Wood);
	}
	public void Drop()
    {
        string type = Helper.DecideBaseOnRange(this.RatioRange);
        if (type == string.Empty)
            return;
		if (type != "heal")
        {
            ElementalToken tempToken = this.ElementalTokenPackedScene.Instantiate<ElementalToken>();
            tempToken.Element = ElementalTokenElementDict[type];
            tempToken.Position = new Vector3(
                this.Position.X - 0.5f,
                this.Position.Y,
                this.Position.Z);
        }
        else
        {
            HealDrop healDrop = this.HealDropPackedScene.Instantiate<HealDrop>();
            healDrop.Position = new Vector3(
                this.Position.X + 0.35f,
                this.Position.Y,
                this.Position.Z + 0.35f);
        }
        SoulOrCoin tempCoin = this.CoinPackedScene.Instantiate<SoulOrCoin>();
        tempCoin.Position = new Vector3(
            this.Position.X + 0.35f,
            this.Position.Y,
            this.Position.Z - 0.35f);
    }
}
