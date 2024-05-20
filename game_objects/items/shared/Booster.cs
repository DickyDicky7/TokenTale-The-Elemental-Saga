using Godot;
using System;
namespace TokenTaleTheElementalSaga;

public abstract partial class Booster : Item3D
{
	[Export]
	public int Key { get; set; }
}
