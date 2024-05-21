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
	public override void ProcessDamage(float Damage)
	{
		Damage += (Damage * this.BonusDamageRatio);
		NextHandler.ProcessDamage(Damage);
	}
}
