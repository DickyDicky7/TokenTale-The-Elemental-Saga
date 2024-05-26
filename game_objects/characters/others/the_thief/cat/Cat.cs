using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cat : Monster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		this.QueueFree();
	}
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{

	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitCat(this);
	}
	public override void _Ready()
	{
		this.Key = "Thief";
		base._Ready();
	}
}
