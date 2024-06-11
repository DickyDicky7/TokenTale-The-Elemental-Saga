using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class TrackingScreen : PanelContainer
{
	[Export]
	public MainCharacter Viewer { get; set; }
	[Export]
	public ShoppingScreen ShoppingScreen { get; set; }
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventKey inputEventKey)
		{
			if (inputEventKey.Pressed)
			{
				if (inputEventKey.Keycode == Key.T)
				{
					this.Visible = !this.Visible;
					if (this.Visible is true)
						this.ShoppingScreen.Visible = false;
				}
				if (inputEventKey.Keycode == Key.Escape)
				{
					this.Visible = false;
				}
			}
		}
	}
}
