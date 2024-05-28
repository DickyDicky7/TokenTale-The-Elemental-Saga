using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class HealTotem : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		CreateAbility(nameof(MiniRootTrap), targetMainCharacter);
	}
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitHealTotem(this);
	}
	public override void _Ready()
	{
		this.Key = "Wood01";
		base._Ready();
	}
}
