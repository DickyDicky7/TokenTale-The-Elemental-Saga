using Godot;
using System;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

[Tool]
[GlobalClass]
public abstract partial class Monster : Character3D
{
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
            new StatusInfoItemElemental {Element = ability.Element, Thing = $"-{damage}🩸" });
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
            new StatusInfoItemHurt { Thing = $"-{damage}🩸" });
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
	}
}
