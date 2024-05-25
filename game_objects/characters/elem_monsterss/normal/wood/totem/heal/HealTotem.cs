using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class HealTotem : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		
	}
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Wood01";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
