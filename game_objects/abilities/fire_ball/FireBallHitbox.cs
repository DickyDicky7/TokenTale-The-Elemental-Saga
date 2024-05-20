using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class FireBallHitbox : Hittbox3D
{
	protected override void OnAreaEntered(Area3D area3D)
	{
		base.OnAreaEntered(area3D);
		Action();
	}
	protected override void Action()
	{
		base.Action();
		float scale = AbilityStats.EffectRadius.Small * 10;
		this.Scale = new Vector3(scale, scale, scale);
		Ability3D temp = this.GetParent() as Ability3D;
	}
}
