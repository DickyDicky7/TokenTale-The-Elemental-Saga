using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ShoppingScreen : PanelContainer
{
	[Export]
	public MainCharacter Viewer { get; set; }
	[Export]
	public GridContainer ShopItemContainer { get; set; }
	public override void _Ready()
	{
		base._Ready();
		Godot.Collections.Array<Node> ShopItems = ShopItemContainer.GetChildren();
		foreach (Node node in ShopItems)
		{
			ShopItem shopItem = node as ShopItem;
			shopItem.ShoppingScreen = this;
		}
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
		if (IsInstanceValid(Viewer) is false)
		{
			this.ProcessMode = ProcessModeEnum.Disabled;
		}
	}
}
