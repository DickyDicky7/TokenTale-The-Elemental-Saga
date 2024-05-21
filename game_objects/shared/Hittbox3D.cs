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
    protected virtual void Action()
    {

    }
	protected float CalculateDamage(
		Area3D currentArea3D,
		Area3D targetArea3D)
	{
		float Damage = 0;
		if (currentArea3D.GetParent() is Ability3D)
		{
			Ability3D tempAbility = currentArea3D.GetParent() as Ability3D;
			if (tempAbility.Caster.GetType() == typeof(MainCharacter))
			{
				MainCharacter tempMainChar = tempAbility.Caster as MainCharacter;
				//Declare base damage
				switch (tempAbility.Element)
				{
					case Global.Element.Fire:
						Damage = tempMainChar.AbilityManager.FireStatus.AbilityInfo.Damage 
							* tempAbility.DamageRatio;
						break;
					case Global.Element.Water:
						Damage = tempMainChar.AbilityManager.WaterStatus.AbilityInfo.Damage
							* tempAbility.DamageRatio;
						break;
					case Global.Element.Wind:
						Damage = tempMainChar.AbilityManager.WindStatus.AbilityInfo.Damage
							* tempAbility.DamageRatio;
						break;
					case Global.Element.Ice:
						Damage = tempMainChar.AbilityManager.IceStatus.AbilityInfo.Damage
							* tempAbility.DamageRatio;
						break;
					case Global.Element.Electric:
						Damage = tempMainChar.AbilityManager.ElectricStatus.AbilityInfo.Damage
							* tempAbility.DamageRatio;
						break;
					case Global.Element.Earth:
						Damage = tempMainChar.AbilityManager.EarthStatus.AbilityInfo.Damage
							* tempAbility.DamageRatio;
						break;
					case Global.Element.Wood:
						Damage = tempMainChar.AbilityManager.WoodStatus.AbilityInfo.Damage
							* tempAbility.DamageRatio;
						break;
				}
				//setup damage handler to calculate
				BaseDH ElementalEquipmentDH = new ElementalEquipmentDH(
					tempMainChar
					.EquipmentManager
					.ElementalBraceletList
					.First(x => x.Key == 0)
					.BonusDamage);
				BaseDH ElementalProficiencyDH = new ElementalProficiencyDH(
					tempMainChar
					.BoosterManager
					.ElementalBonusDamageRatio);
				BaseDH ElementalReactionDH = null;
				if (targetArea3D.GetParent() is ElementalMonster)
				{
					ElementalMonster temp = targetArea3D.GetParent() as ElementalMonster;
					ElementalReactionDH = new ElementalReactionDH(
						temp.Element,
						tempAbility.Element,
						true);
				}
				else if (targetArea3D.GetParent() is Monster)
				{
					Monster temp = targetArea3D.GetParent() as Monster;
					if (temp.ElementMark == Global.Element.None)
					{
						temp.ElementMark = tempAbility.Element;
					}
					else
					{
						ElementalReactionDH = new ElementalReactionDH(
							temp.ElementMark,
							tempAbility.Element,
							false);
						temp.ElementMark = Global.Element.None;
					}
				}
				//calculate Damage
				ElementalEquipmentDH.SetNextHandler(ElementalProficiencyDH);
				if (ElementalReactionDH != null)
					ElementalProficiencyDH.SetNextHandler(ElementalReactionDH);
				ElementalEquipmentDH.ProcessDamage(Damage);
			}
		}
		return Damage;
	}
}


