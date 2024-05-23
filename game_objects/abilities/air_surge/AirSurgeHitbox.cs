using Godot;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class AirSurgeHitbox : Hittbox3D
{
	public float PushSpeed { get; private set; } = AbilityStats.Speed.Fast;
	public List<Rid> ExceptionRidList { get; private set; } = new();
	protected override void OnBodyEntered(Node3D node3D)
	{
		base.OnBodyEntered(node3D);
		if (this.GetParent() is Ability3D tempAbility && node3D is Monster tempMonster)
		{
			this.PushMonsterAside(tempAbility, tempMonster);
			if (ExceptionRidList.Find(x => x == tempMonster.GetRid()) != default)
				return;
			else
				ExceptionRidList.Add(tempMonster.GetRid());
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
		Vector3 pushDirection = ability.GlobalPosition.DirectionTo(monster.GlobalPosition);
		pushDirection = new Vector3(pushDirection.X, 0, pushDirection.Z).Normalized();
		monster.Velocity = pushDirection * this.PushSpeed;
		monster.MoveAndSlide();
		monster.Velocity = Vector3.Zero;
	}
}
