using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public abstract partial class Monster : Character3D
{
	public abstract void Attack(Character3D target);
}
