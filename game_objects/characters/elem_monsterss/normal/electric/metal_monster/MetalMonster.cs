using Godot;
using System.Runtime.CompilerServices;

namespace TokenTaleTheElementalSaga;

public partial class MetalMonster : ElementalMonster
{
	
    public override void Attack(Character3D target)
    {

    }
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Electric01";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
