using Godot;
using System;
namespace TokenTaleTheElementalSaga;
//CHAIN OF RESPONSIBILITY
public partial class ElementalEquipmentDH : BaseDH
{
	public float BonusDamage { get; private set; }
	public ElementalEquipmentDH(float BonusDamage)
	{
		this.BonusDamage = BonusDamage;
	}
	public override void ProcessDamage(ref float Damage)
	{
		Damage += BonusDamage;
		if (this.NextHandler is not null)
			NextHandler.ProcessDamage(ref Damage);
	}
}