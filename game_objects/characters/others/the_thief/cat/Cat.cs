using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Cat : Monster
{
	public override void Attack(MainCharacter targetMainCharacter)
	{
		//int energyLost = (int)(targetMainCharacter.BoosterManager.MaxEnergy * 0.5);
		//targetMainCharacter.CurrentEnergy -= energyLost;
		//targetMainCharacter.StatusInfo.Items.Add(
		//	new StatusInfoItemElemental { Element = Global.Element.None, Thing = $"-{energyLost}⚡" });
		this.QueueFree();
	}
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitCat(this);
	}
	public override void _Ready()
	{
		this.Key = "Thief";
		base._Ready();
	}
}
