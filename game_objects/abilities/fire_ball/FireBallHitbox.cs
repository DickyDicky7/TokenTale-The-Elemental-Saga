using Godot;
using System;
using System.Linq;
using System.Linq.Expressions;
namespace TokenTaleTheElementalSaga;

public partial class FireBallHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		if (Hit == false)
		{
			base.OnBodyEntered(node3D);
			Action();
			float Damage = 0;
			if (this.GetParent() is Ability3D)
			{
				Ability3D tempAbility = this.GetParent() as Ability3D;
				if (node3D is Monster)
				{
					Monster tempMonster = node3D as Monster;
					Damage = CalculateDamage(tempAbility, tempMonster);
					tempMonster.CurrentHealth -= Damage;
				}
				tempAbility.DamageRatio = 0.8f;
			}
		}
		else
		{
			float Damage = 0;
			if (this.GetParent() is Ability3D && node3D is Monster)
			{
				Ability3D tempAbility = this.GetParent() as Ability3D;
				Monster tempMonster = node3D as Monster;
				Damage = CalculateDamage(tempAbility, tempMonster);
				tempMonster.CurrentHealth -= Damage;
			}
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
