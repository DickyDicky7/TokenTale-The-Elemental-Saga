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
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{

	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitImp(this);
	}
	public override void _Ready()
	{
		this.Key = "Fire01";
		base._Ready();
	}
}
