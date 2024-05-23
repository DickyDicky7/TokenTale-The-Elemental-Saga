using Godot;
using System;
using TokenTaleTheElementalSaga;

public partial class SkyStrikeHitbox : Hittbox3D
{
	private float PushSpeed { get; set; } = AbilityStats.Speed.Fast;
	protected override void OnBodyEntered(Node3D node3D)
	{
		float Damage = 0;
		if (this.GetParent() is Ability3D tempAbility&& node3D is Monster tempMonster)
		{
			Damage = CalculateDamage(tempAbility, tempMonster);
			tempMonster.CurrentHealth -= Damage;
			tempMonster.EmitSignal(Character3D.SignalName.HealthChange, Damage);
			//this.PushMonsterAside(tempAbility, tempMonster);
		}
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.Small;
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
	}
	private void PushMonsterAside(Ability3D ability, Monster monster)
	{
		Vector3 PushDirection = ability.GlobalPosition.DirectionTo(monster.GlobalPosition);
		PushDirection = new Vector3(PushDirection.X, 0, PushDirection.Z).Normalized();
		monster.Velocity = PushDirection * this.PushSpeed * 5;
		monster.MoveAndSlide();
		monster.Velocity = Vector3.Zero;
	}
}
