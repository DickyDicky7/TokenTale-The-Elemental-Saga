using Godot;

namespace TokenTaleTheElementalSaga;

public partial class RatfolkMage : ElementalMonster
{
	public float ProjectileSpeed { get; set; }
	public float ProjectileAcceleration { get; set; }
	public float ProjectileDeceleration { get; set; }
	public override void Attack(MainCharacter targetMainCharacter)
	{
		CreateAbility(nameof(MiniPenetratingSquirt), targetMainCharacter);
	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitRatfolkMage(this);
	}
	public override void _Ready()
	{
		this.Key = "Water01";
		base._Ready();
	}
}
