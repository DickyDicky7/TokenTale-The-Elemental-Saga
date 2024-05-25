using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public partial class KoboldPriest : ElementalMonster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		
	}
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Ice01";
	}
}
