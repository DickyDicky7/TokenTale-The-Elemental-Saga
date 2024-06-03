using Godot;
using Godot.Collections;
using System;
using System.Runtime.CompilerServices;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MainCharacter : Character3D
{
    [Export]
    public MainCharacterHUDController HUDController { get; set; }
    [Export]
    public WeaponsController WeaponsController { get; set; }
    [Export]
    public AlliesVisitor VisitorAbilityDispatch { get; set; }
    [Export]
    public NavigationAgent3D
           NavigationAgent3D
    {
        get;
        set;
    }
    [Export]
    public NavigationRegion3D NavigationRegion3DStatic { get; set; }

    [Export]
    public MainCharacterAnimatedSprite3DEffect
           MainCharacterAnimatedSprite3DEffect
    {
        get;
        set;
    }
    public EquipmentManager EquipmentManager { get; private set; } 
    public   AbilityManager   AbilityManager { get; private set; } 
    public   BoosterManager   BoosterManager { get; private set; } 
    public MainCharacter()
    {
        SetupStats();
    }
	public override void _Ready()
	{
        base._Ready();
        this.SetupStats();
        this.SetupVisitor();
	}

	public override void _Process(double @delta)
    {
                    base._Process(       @delta);
	}

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);
	}
    private void AcceptVisitor(AlliesVisitor visitor)
    {
        visitor.VisitMainCharacter(this);
    }
    private void SetupVisitor()
    {
		this.VisitorAbilityDispatch.Init();
		this.AcceptVisitor(VisitorAbilityDispatch);
	}
    private void SetupStats()
    {
        //WARNING: do not change the order
		this.BoosterManager = new BoosterManager();
		this.MaxHealth = BoosterManager.MaxHealth;
		this.EquipmentManager = new EquipmentManager(this);
		this.MaxSpeed = EquipmentManager.Boot.Speed;
		this.CurrentHealth = MaxHealth;
		this.CurrentSpeed = this.MaxSpeed;
		this.AbilityManager = new AbilityManager();
	}
	public override float CalculateElementalDamage(Ability3D ability,Character3D targetCharacter)
	{
        float damage = 0;
        if (targetCharacter is not Monster)
            return damage;
        damage = this
			.AbilityManager
			.ElementStatus[ability.Element]
			.AbilityInfo
			.Damage
			* ability.DamageRatio;
		//setup damage handler to calculate
		BaseDH elementalEquipmentDH = new ElementalEquipmentDH(
			this
			.WeaponsController
			.ChosenBracelet 
			.BonusDamage);
		BaseDH elementalProficiencyDH = new ElementalProficiencyDH(
			this
			.BoosterManager
			.ElementalBonusDamageRatio);
		BaseDH elementalReactionDH = null;
        if (targetCharacter is ElementalMonster targetElementalMonster)
        {
			elementalReactionDH = new ElementalReactionDH(
				targetElementalMonster.Element,
				ability.Element,
				true);
		}
        else if (targetCharacter.ElementMark == Global.Element.None)
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
        //calculate Damage
		elementalEquipmentDH.SetNextHandler(elementalProficiencyDH);
		if (elementalReactionDH != null)
			elementalProficiencyDH.SetNextHandler(elementalReactionDH);
		elementalEquipmentDH.ProcessDamage(ref damage);
		//GD.Print(damage);
		damage = (float)Math.Round(damage, 2);
		targetCharacter.StatusInfo.Items.Add(
            new StatusInfoItemElemental { Element = ability.Element, Thing = $"-{damage}🩸" });
		return damage;
	}
	public override float CalculatePhysicsDamage(Character3D targetCharacter)
	{
		float damage = 0;
		if (targetCharacter is not Monster)
			return damage;
        if (this.WeaponsController.ChosenWeapon is Sword tempSword)
        {
            damage = tempSword.Damage;
            BaseDH swordProficiencyDH = new SwordProficiencyDH(
                this.BoosterManager.SwordBonusDamageRatio);
            swordProficiencyDH.ProcessDamage(ref damage);
        }
        else if (this.WeaponsController.ChosenWeapon is _Bow_ tempBow)
        {
            damage = tempBow.Damage;
			BaseDH bowProficiencyDH = new BowProficiencyDH(
				this.BoosterManager.BowBonusDamageRatio);
            bowProficiencyDH.ProcessDamage(ref damage);
		}
		damage = (float)Math.Round(damage, 2);
		targetCharacter.StatusInfo.Items.Add(
            new StatusInfoItemHurt { Thing = $"-{damage}🩸" });
        return damage;
	}
    public void CreateAbility (string abilityName)
    {
        Ability3D ability = this
            .AbilityPackedScenes[abilityName]
            .Instantiate<Ability3D>();
        Vector3 globalMousePosition = this.GetGlobalMousePosition();
        ability.Attach(
            this.NavigationRegion3DStatic,
            this,
            this.NavigationRegion3DStatic.ToLocal(this.GlobalPosition),
            this.NavigationRegion3DStatic.ToLocal(globalMousePosition));
        this.MainCharacterAnimatedSprite3DEffect.CurrentEffect =
        this.MainCharacterAnimatedSprite3DEffect.EffectDictionary[ability.Element];
    }
    public string Cast(Global.Element element)
    {
        string abilityName = this
            .AbilityManager
            .ElementStatus[element]
            .ChosenAbility;
        CreateAbility(abilityName);
        this.AbilityManager.UpdateStatus(element);
        return abilityName;
    }
}















