using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class HealDrop : Node3D
{
	public float RandomizeAmouthOfHealth()
	{
		RandomNumberGenerator rand = new RandomNumberGenerator();
		return rand.RandfRange(15.0f, 25.0f);
	}
}
