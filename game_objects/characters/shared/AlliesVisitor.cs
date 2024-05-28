using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[Tool]
[GlobalClass]
public abstract partial class AlliesVisitor : Resource
{
	public abstract void Init();
	public abstract void VisitMainCharacter(MainCharacter mainCharacter);
}
