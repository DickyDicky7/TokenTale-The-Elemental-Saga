using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Imp : ElementalMonster
{
	public float ProjectileSpeed { get; set; }
	public float ProjectileAcceleration { get; set; }
	public float ProjectileDeceleration { get; set; }
	public override void Attack(MainCharacter targetMainCharacter)
	{
		
	}
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Fire01";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
