using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class CollectorBox3d : CustomArea3D
{
	protected override void OnAreaEntered(Area3D @area3D)
	{
		if (this.GetParent() is MainCharacter tempMainCharacter)
		{
			if (area3D.GetParent() is ElementalToken tempElementalToken)
				TakeElementalToken(tempMainCharacter, tempElementalToken);
		}
	}
	protected override void OnBodyEntered(Node3D @node3D)
	{
		if (this.GetParent() is MainCharacter tempMainCharacter)
		{
			if (node3D is ElementalToken tempElementalToken)
				TakeElementalToken(tempMainCharacter, tempElementalToken);
		}
	}
	private void TakeElementalToken(MainCharacter mainCharacter, ElementalToken elementalToken)
	{
		foreach (ElementalBracelet elementalBracelet in mainCharacter.WeaponsController.Bracelets)
		{
			if (elementalBracelet.CurrentElement == Global.Element.None)
			{
				elementalBracelet.CurrentElement = elementalToken.Element;
				elementalBracelet.CurrentEnergy = mainCharacter.BoosterManager.MaxEnergy;
				elementalBracelet.EmitSignal(ElementalBracelet.SignalName.Recharge, elementalBracelet);
				elementalToken.QueueFree();
				break;
			}
		}
	}
	public override void _Ready()
	{
		base._Ready();
		this.StartWatching();
	}
}
