using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class Bat : ElementalMonster
{
    public override void Attack(Character3D target)
    {
		
    }
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Wind01";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
