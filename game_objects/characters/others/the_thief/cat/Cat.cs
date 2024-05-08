using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cat : Monster
{
	public override void Attack(Character3D target)
	{
		this.QueueFree();
	}
}
