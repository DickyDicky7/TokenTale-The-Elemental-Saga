using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class TrackingScreen : PanelContainer
{
	[Export]
	public MainCharacter Viewer { get; set; }
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
				}
			}
		}
	}
}
