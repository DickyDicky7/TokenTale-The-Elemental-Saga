using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class Bat : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{

	}
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Wind01";
	}
}
