using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ShoppingScreen : PanelContainer
{
	[Export]
	public MainCharacter Viewer { get; set; }
	[Export]
	public GridContainer ShopItemContainer { get; set; }
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
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
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventKey inputEventKey)
		{
			if (inputEventKey.Pressed)
			{
				if (inputEventKey.Keycode == Key.B)
				{
					this.Visible = !this.Visible;
					if (this.Visible is true)
						this.TrackingScreen.Visible = false;
				}
				if (inputEventKey.Keycode == Key.Escape)
				{
					this.Visible = false;
				}
			}
		}
	}
}
