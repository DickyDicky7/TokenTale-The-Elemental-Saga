using Godot;
using System;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MainCharacter : Character3D
{
    [Export]
    public NavigationAgent3D
           NavigationAgent3D
    {
        get;
        set;
    }

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

	public override void _Ready()
	{
        base._Ready();
        this.EquipmentManager = new EquipmentManager();
        this.  BoosterManager = new   BoosterManager();
        this.  AbilityManager = new   AbilityManager();
        this.MaxHealth = BoosterManager.MaxHealth;
        this.Speed = EquipmentManager.Boot.Speed;
        this.CurrentHealth = MaxHealth;
        this.CurrentSpeed = this.Speed;
	}

	public override void _Process(double @delta)
    {
                    base._Process(       @delta);
        //SingletonMainCharacterTracesManager.Instance.Add(Position);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
                    base._UnhandledInput(           @event);

        if (@event.IsActionPressed("DUMMY"))
        {
            GetNode<Node>(nameof(StateMachine)).ProcessMode    =
                                                ProcessModeEnum.Disabled;
        }

        if (@event.IsActionPressed("SPACE")
        &&  GetNode<Node>(nameof(StateMachine)).ProcessMode   ==
                                                ProcessModeEnum.Disabled)
        {
            Vector3 randomPosition =
                    GlobalPosition +
            Vector3.Zero with
            {
                X = (float)GD.RandRange(-5, 5),
                Z = (float)GD.RandRange(-5, 5),
            };
            NavigationAgent3D.TargetPosition =
                              randomPosition ;
        }
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
			.EquipmentManager
			.ElementalBraceletList
			.Find(x => x.Key ==0) //Change later when toggle elemental ready
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
            new StatusInfoItemElemental { Element = ability.Element, Thing = $"-{damage}" });
		return damage;
	}
	public override float CalculatePhysicsDamage(Character3D targetCharacter)
	{
		float damage = 0;
		if (targetCharacter is not Monster)
			return damage;
		damage = (float)Math.Round(damage, 2);
		targetCharacter.StatusInfo.Items.Add(
            new StatusInfoItemHurt { Thing = $"-{damage}" });
        return damage;
	}
}















