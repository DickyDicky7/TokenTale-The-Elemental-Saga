using Godot;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class AirSurgeHitbox : Hittbox3D
{
	public float PushSpeed { get; private set; } = AbilityStats.Speed.Fast;
	public List<Rid> ExceptionRidList { get; private set; } = new();
	protected override void OnBodyEntered(Node3D node3D)
	{
		float Damage = 0;
		if (this.GetParent() is Ability3D tempAbility && node3D is Monster tempMonster)
		{
			this.PushMonsterAside(tempAbility, tempMonster);
			if (ExceptionRidList.Find(x => x == tempMonster.GetRid()) != default)
				return;
			else
				ExceptionRidList.Add(tempMonster.GetRid());
			Damage = CalculateDamage(tempAbility, tempMonster);
			tempMonster.CurrentHealth -= Damage;
			tempMonster.EmitSignal(Character3D.SignalName.HealthChange, Damage);
		}
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.XSmall;
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
	}
	private void PushMonsterAside(Ability3D ability, Monster monster)
	{
		Vector3 PushDirection = ability.GlobalPosition.DirectionTo(monster.GlobalPosition);
		PushDirection = new Vector3(PushDirection.X, 0, PushDirection.Z).Normalized();
		monster.Velocity = PushDirection * this.PushSpeed;
		monster.MoveAndSlide();
		monster.Velocity = Vector3.Zero;
	}
}
