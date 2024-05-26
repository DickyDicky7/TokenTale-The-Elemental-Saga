using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class MThrowingRockHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		if (this.GetParent() is Ability3D tempAbility)
		{
			float distance = tempAbility.Caster.GlobalPosition.DistanceTo(node3D.GlobalPosition);
			if (0 <= distance && distance <= AbilityStats.ActiveRange.Short)
			{
				tempAbility.DamageRatio = 0.8f;
			}
			else if (AbilityStats.ActiveRange.Short < distance 
				&& distance <= AbilityStats.ActiveRange.Medium)
			{
				tempAbility.DamageRatio = 1.0f;
			}
			else if (AbilityStats.ActiveRange.Medium < distance
				&& distance <= AbilityStats.ActiveRange.Long)
			{
				tempAbility.DamageRatio = 1.2f;
			}
			else if (AbilityStats.ActiveRange.Long < distance
				&& distance <= AbilityStats.ActiveRange.Great)
			{
				tempAbility.DamageRatio = 1.4f;
			}
		}
		base.OnBodyEntered(node3D);
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.Small;
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
	}
}
