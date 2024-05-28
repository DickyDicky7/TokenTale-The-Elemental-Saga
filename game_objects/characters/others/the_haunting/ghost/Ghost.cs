using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Ghost : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {
        this.QueueFree();
    }
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitGhost(this);
	}
	public override void _Ready()
	{
		this.Key = "Haunt";
		base._Ready();
	}
}
