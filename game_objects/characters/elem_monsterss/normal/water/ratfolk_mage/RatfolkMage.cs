using Godot;

namespace TokenTaleTheElementalSaga;

public partial class RatfolkMage : ElementalMonster
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
		this.Key = "Water01";
	}
}
