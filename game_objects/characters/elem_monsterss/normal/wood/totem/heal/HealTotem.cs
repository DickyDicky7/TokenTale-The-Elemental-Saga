using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class HealTotem : ElementalMonster
{
    public override void Attack(Character3D target)
    {
		
    }
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Wood01";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
	}
}
