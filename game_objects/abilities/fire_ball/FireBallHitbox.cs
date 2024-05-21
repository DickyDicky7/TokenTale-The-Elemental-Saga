using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;

public partial class FireBallHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Area3D area3D)
	{
		if (this.Hit == false)
		{
			base.OnAreaEntered(area3D);
			Action();
			float Damage = CalculateDamage(this, area3D);
			if (this.GetParent() is Ability3D)
			{
				Ability3D temp = this.GetParent() as Ability3D;
				temp.DamageRatio = 0.8f;
			}
		}
		else
		{
			float Damage = CalculateDamage(this, area3D);
		}
	}
	public override void _Ready()
	{
		base._Ready();
		this.EffectRadius = AbilityStats.EffectRadius.Small * 10;
	}
	protected override void Action()
	{
		base.Action();
		this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
		Ability3D temp = this.GetParent() as Ability3D;
		temp.Stop();
	}
}
