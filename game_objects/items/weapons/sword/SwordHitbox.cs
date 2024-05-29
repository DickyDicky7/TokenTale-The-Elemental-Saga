using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class SwordHitbox : Hittbox3D
{
	private float PushSpeed { get; set; } = 5.0f;
	protected override void OnBodyEntered(Node3D node3D)
	{
		base.OnBodyEntered(node3D);
		if (this.GetParent() is Sword tempSword && node3D is Monster tempMonster)
		{
			PushMonsterAside(tempSword, tempMonster);
		}
	}
	public override void _Ready()
	{
		base._Ready();
	}
	private void PushMonsterAside(Sword sword, Monster monster)
	{
		Vector3 pushDirection = sword.GlobalPosition.DirectionTo(monster.GlobalPosition);
		pushDirection = new Vector3(pushDirection.X, 0, pushDirection.Z).Normalized();
		monster.BePushed(pushDirection * this.PushSpeed);
	}
}
