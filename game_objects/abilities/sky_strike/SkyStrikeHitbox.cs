using Godot;
using System;
using TokenTaleTheElementalSaga;

public partial class SkyStrikeHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.Small * 4;
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
	}
	protected override void Action()
	{
		base.Action();
	}
}
