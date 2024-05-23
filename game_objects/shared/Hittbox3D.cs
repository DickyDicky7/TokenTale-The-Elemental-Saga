using Godot;
using System.Linq;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class Hittbox3D : CustomArea3D
{
    public float EffectRadius { get; protected set; }
    public bool Hit { get; set; } = false;
    protected override void OnAreaEntered(Area3D @area3D)
    {
		this.Hit = true;
    }
	protected override void OnBodyEntered(Node3D @node3D)
	{
		this.Hit = true;
	}
	protected float CalculateDamage(
		Ability3D currentAbility3D,
		Monster targetMonster3D)
	{
		float Damage = 0;
		if (currentAbility3D.Caster is MainCharacter )
		{
			MainCharacter tempMainChar = currentAbility3D.Caster as MainCharacter;
			//Declare base damage
			Damage = tempMainChar
				.AbilityManager
				.ElementStatus[currentAbility3D.Element]
				.AbilityInfo
				.Damage
				* currentAbility3D.DamageRatio;
			//setup damage handler to calculate
			BaseDH ElementalEquipmentDH = new ElementalEquipmentDH(
				tempMainChar
				.EquipmentManager
				.ElementalBraceletList
				.First(x => x.Key == 0) //Change later when toggle elemental ready
				.BonusDamage);
			BaseDH ElementalProficiencyDH = new ElementalProficiencyDH(
				tempMainChar
				.BoosterManager
				.ElementalBonusDamageRatio);
			BaseDH ElementalReactionDH = null;
			if (targetMonster3D is ElementalMonster)
			{
				ElementalMonster tempElementMonster = targetMonster3D as ElementalMonster;
				ElementalReactionDH = new ElementalReactionDH(
					tempElementMonster.Element,
					currentAbility3D.Element,
					true);
			}
			else if(targetMonster3D.ElementMark == Global.Element.None)
			{
				targetMonster3D.ElementMark = currentAbility3D.Element;
			}
			else
			{
				ElementalReactionDH = new ElementalReactionDH(
					targetMonster3D.ElementMark,
					currentAbility3D.Element,
					false);
				targetMonster3D.ElementMark = Global.Element.None;
			}
			//calculate Damage
			ElementalEquipmentDH.SetNextHandler(ElementalProficiencyDH);
			if (ElementalReactionDH != null)
				ElementalProficiencyDH.SetNextHandler(ElementalReactionDH);
			ElementalEquipmentDH.ProcessDamage(ref Damage);
			GD.Print(Damage);
		}
		return Damage;
	}
}


