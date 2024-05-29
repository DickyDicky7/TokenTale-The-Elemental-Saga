using Godot;
using Godot.Collections;
using System;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MainCharacter : Character3D
{
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
    public int CurrentEnergy { get; set; }
    public EquipmentManager EquipmentManager { get; private set; } 
    public   AbilityManager   AbilityManager { get; private set; } 
    public   BoosterManager   BoosterManager { get; private set; } 

	public override void _Ready()
	{
        base._Ready();
        this.EquipmentManager = new EquipmentManager();
        this.  BoosterManager = new   BoosterManager();
        this.  AbilityManager = new   AbilityManager();
        this.MaxHealth = BoosterManager.MaxHealth;
        this.MaxSpeed = EquipmentManager.Boot.Speed;
        this.CurrentHealth = MaxHealth;
        this.CurrentSpeed = this.MaxSpeed;
        this.CurrentEnergy = BoosterManager.MaxEnergy;
        this.VisitorAbilityDispatch.Init();
        this.AcceptVisitor(VisitorAbilityDispatch);
	}

	public override void _Process(double @delta)
    {
                    base._Process(       @delta);
        //SingletonMainCharacterTracesManager.Instance.Add(Position);
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        if (GetNode<Node>(nameof(StateMachine)).ProcessMode   ==
                                                ProcessModeEnum.Disabled)
        {
            var destination = NavigationAgent3D.GetNextPathPosition();
            var   direction =
                destination -
             GlobalPosition ;
            Move( direction , @delta);
        }
    }
    public void AcceptVisitor(AlliesVisitor visitor)
    {
        visitor.VisitMainCharacter(this);
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
    public void Cast(Global.Element element)
    {
        string abilityName = this
            .AbilityManager
            .ElementStatus[element]
            .ChosenAbility;
        CreateAbility(abilityName);
        this.AbilityManager.UpdateStatus(element);
    }
}















