using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cat : Monster
{
	public override void Attack(Character3D target)
	{
		this.QueueFree();
	}
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Thief";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
