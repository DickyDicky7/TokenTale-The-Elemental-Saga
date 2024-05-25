using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Ghost : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {
        this.QueueFree();
    }
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Haunt";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
