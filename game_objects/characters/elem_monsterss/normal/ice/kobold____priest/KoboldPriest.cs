using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class KoboldPriest : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		this.CreateAbility(nameof(MiniIceShard), targetMainCharacter);
	}
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitKoboldPriest(this);
	}
	public override void _Ready()
	{
		this.Key = "Ice01";
		base._Ready();
	}
}
