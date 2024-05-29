using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class BowProficiencyDH : BaseDH
{
	public float BonusDamageRatio { get; private set; }
	public BowProficiencyDH(float BonusDamageRatio)
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
