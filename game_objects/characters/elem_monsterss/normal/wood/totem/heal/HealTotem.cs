using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class HealTotem : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		
	}
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{

	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitHealTotem(this);
	}
	public override void _Ready()
	{
		this.Key = "Wood01";
		base._Ready();
	}
}
