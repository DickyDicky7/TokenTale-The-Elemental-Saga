using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Skeleton : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {

    }
	public override void CreateAbility(MainCharacter targetMainCharacter)
	{

	}
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitSkeleton(this);
	}
	public override void _Ready()
	{
		this.Key = "Undead";
		base._Ready();
	}
}
