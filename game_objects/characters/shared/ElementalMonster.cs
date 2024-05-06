using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class ElementalMonster : Monster
{
	[Export]
	private Global.Element Element { get; set; }
}
