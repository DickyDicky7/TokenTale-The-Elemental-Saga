using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class ElementalMonster : Monster
{
	[Export]
	public Global.Element Element { get; set; }
}
