using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cyclops : ElementalMonster
{
    public float ProjectileSpeed { get; set; }
    public float ProjectileAcceleration { get; set; }
    public float ProjectileDeceleration { get; set; }
    public override void Attack(Character3D target)
    {

    }
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Earth01";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
	}
}
