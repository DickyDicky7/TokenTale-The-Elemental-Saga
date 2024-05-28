using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cyclops : ElementalMonster
{
    public float ProjectileSpeed { get; set; }
    public float ProjectileAcceleration { get; set; }
    public float ProjectileDeceleration { get; set; }
	public override void Attack(MainCharacter targetMainCharacter)
	{
		this.CreateAbility(nameof(MiniThrowingRock), targetMainCharacter);
	}
	public override void CreateAbility(string abilityName, MainCharacter targetMainCharacter)
	{
		Ability3D tempAbility = this
			.AbilityPackedScenes[nameof(abilityName)]
			.Instantiate<Ability3D>();
		tempAbility.Attach(
			this.NavigationRegion3DStatic,
			this,
			NavigationRegion3DStatic.ToLocal(this.GlobalPosition),
			NavigationRegion3DStatic.ToLocal(targetMainCharacter.GlobalPosition));
		float distance = this.GlobalPosition.DistanceTo(targetMainCharacter.GlobalPosition);
		if (0 <= distance && distance <= AbilityStats.ActiveRange.Short)
		{
			tempAbility.DamageRatio = 0.8f;
		}
		else if (AbilityStats.ActiveRange.Short < distance
			&& distance <= AbilityStats.ActiveRange.Medium)
		{
			tempAbility.DamageRatio = 1.0f;
		}
		else if (AbilityStats.ActiveRange.Medium < distance
			&& distance <= AbilityStats.ActiveRange.Long)
		{
			tempAbility.DamageRatio = 1.2f;
		}
		else if (AbilityStats.ActiveRange.Long < distance
			&& distance <= AbilityStats.ActiveRange.Great)
		{
			tempAbility.DamageRatio = 1.4f;
		}
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
