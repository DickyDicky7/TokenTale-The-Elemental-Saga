using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Imp : ElementalMonster
{
	public float ProjectileSpeed { get; set; }
	public float ProjectileAcceleration { get; set; }
	public float ProjectileDeceleration { get; set; }
	public override void Attack(MainCharacter targetMainCharacter)
	{
		this.CreateAbility(nameof(MiniFireBall), targetMainCharacter);
	}
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitImp(this);
	}
	public override void _Ready()
	{
		this.Key = "Fire01";
		base._Ready();
	}
}
