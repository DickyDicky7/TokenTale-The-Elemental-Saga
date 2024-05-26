using Godot;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TokenTaleTheElementalSaga;

public partial class MetalMonster : ElementalMonster
{
	private int Charge { get; set; } = 0;
	private float StunDuration { get; set; } = 1.0f;
    public override void Attack(MainCharacter targetMainCharacter)
    {
		this.CreateAbility(targetMainCharacter);
	}
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{
		Ability3D tempAbility = this
			.AbilityPackedScenes[nameof(MiniThunderShock)]
			.Instantiate<Ability3D>();
		tempAbility.Attach(
			this.NavigationRegion3DStatic,
			this,
			NavigationRegion3DStatic.ToLocal(this.GlobalPosition),
			NavigationRegion3DStatic.ToLocal(targetMainCharacter.GlobalPosition));
	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitMetalMonster(this);
	}
	public void Shock(MainCharacter targetMainCharacter)
	{
		if (this.Charge < 3)
		{
			Charge++;
		}
		else
		{
			this.Charge = 0;
			targetMainCharacter.StartStun(StunDuration);
		}
	}
	public override void _Ready()
	{
		this.Key = "Electric01";
		base._Ready();
	}
}
