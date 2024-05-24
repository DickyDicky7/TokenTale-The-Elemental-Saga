using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class SquirtHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		if (node3D is CollisionObject3D tempObject)
		{
			if (tempObject.CollisionLayer == 1 || tempObject.CollisionLayer == 2)
				Stop();
		}
		if (Hit == false)
		{
			base.OnBodyEntered(node3D);
			Ability3D tempAbility = this.GetParent() as Ability3D;
			tempAbility.DamageRatio = 0.8f;
		}
		else
		{
			base.OnBodyEntered(node3D);
		}
	}
	public override void _Ready()
	{
		base._Ready();
	}
	private void Stop()
	{
		Ability3D temp = this.GetParent() as Ability3D;
		temp.Stop();
	}
}
