using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Skeleton : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {

    }
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Undead";
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
