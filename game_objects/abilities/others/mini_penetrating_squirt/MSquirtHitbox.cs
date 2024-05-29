using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class MSquirtHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		base.OnBodyEntered(node3D);
		if (this.GetParent() is Ability3D tempAbility)
		{
			if (node3D is StaticBody3D)
			{
				tempAbility.Stop();
				tempAbility.QueueFree();
			}
		}
	}
	public override void _Ready()
	{
		base._Ready();
	}
}
