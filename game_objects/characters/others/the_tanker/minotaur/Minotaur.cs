using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Minotaur : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {

    }
	public override void AcceptVisitor(MonsterVisitor visitor)
	{
		visitor.VisitMinotaur(this);
	}
	public override void _Ready()
	{
		this.Key = "Tanker";
		base._Ready();
	}
}
