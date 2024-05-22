using Godot;
using System;
namespace TokenTaleTheElementalSaga;
//CHAIN OF RESPONSIBILITY
public partial class ElementalProficiencyDH : BaseDH
{
	public float BonusDamageRatio { get; private set; }
	public ElementalProficiencyDH(float BonusDamageRatio)
	{
		this.BonusDamageRatio = BonusDamageRatio;
	}
	public override void ProcessDamage(ref float Damage)
	{
		Damage += (Damage * this.BonusDamageRatio);
		if (this.NextHandler is not null)
			NextHandler.ProcessDamage(ref Damage);
	}
}
