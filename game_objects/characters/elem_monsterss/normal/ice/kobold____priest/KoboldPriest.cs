using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class KoboldPriest : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		
	}
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{

	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitKoboldPriest(this);
	}
	public override void _Ready()
	{
		this.Key = "Ice01";
		base._Ready();
	}
}
