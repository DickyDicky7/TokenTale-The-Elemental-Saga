using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cyclops : ElementalMonster
{
    public float ProjectileSpeed { get; set; }
    public float ProjectileAcceleration { get; set; }
    public float ProjectileDeceleration { get; set; }
	public override void Attack(MainCharacter targetMainCharacter)
	{
		CreateAbility(targetMainCharacter);
	}
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{
		Ability3D tempAbility = this
			.AbilityPackedScenes[nameof(MiniThrowingRock)]
			.Instantiate<Ability3D>();
		tempAbility.Attach(
			this.NavigationRegion3DStatic,
			this,
			NavigationRegion3DStatic.ToLocal(this.GlobalPosition),
			NavigationRegion3DStatic.ToLocal(targetMainCharacter.GlobalPosition));
	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitCyclops(this);
	}
	public override void _Ready()
	{
		this.Key = "Earth01";
		base._Ready();
	}
}
