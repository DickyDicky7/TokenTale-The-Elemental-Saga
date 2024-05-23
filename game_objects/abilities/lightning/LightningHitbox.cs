using Godot;
using System;
using static TokenTaleTheElementalSaga.AbilityStats;
namespace TokenTaleTheElementalSaga;
public partial class LightningHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		base.OnBodyEntered(node3D);
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.Small;
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
	}
}
