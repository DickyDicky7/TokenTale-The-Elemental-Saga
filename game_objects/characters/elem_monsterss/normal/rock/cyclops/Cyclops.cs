using Godot;
using System;

namespace TokenTaleTheElementalSaga;
public partial class Cyclops : ElementalMonster
{
	[Export]
	public float ProjectileSpeed { get; set; }
	[Export]
	public float ProjectileAcceleration { get; set; }
	[Export]
	public float ProjectileDeceleration { get; set; }
	public override void Attack(Character3D target)
	{
		
	}
}
