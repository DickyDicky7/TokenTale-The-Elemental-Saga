using Godot;
using System;
using TokenTaleTheElementalSaga;

public partial class SkyStrikeHitbox : Hittbox3D
{
	private float PushSpeed { get; set; } = AbilityStats.Speed.Fast;
	protected override void OnBodyEntered(Node3D node3D)
	{
		base.OnBodyEntered(node3D);
		//if (this.GetParent() is Ability3D tempAbility && node3D is Monster tempMonster)
		//{
		//	this.PushMonsterAside(tempAbility, tempMonster);
		//}
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.Small;
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
	}
	private void PushMonsterAside(Ability3D ability, Monster monster)
	{
		Vector3 pushDirection = ability.GlobalPosition.DirectionTo(monster.GlobalPosition);
		pushDirection = new Vector3(pushDirection.X, 0, pushDirection.Z).Normalized();
		monster.Velocity = pushDirection * this.PushSpeed * 5;
		monster.MoveAndSlide();
		monster.Velocity = Vector3.Zero;
	}
}
