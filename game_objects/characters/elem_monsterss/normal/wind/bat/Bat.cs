using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class Bat : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{

	}
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{

	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitBat(this);
	}
	public override void _Ready()
	{
		this.Key = "Wind01";
		base._Ready();
	}
}
