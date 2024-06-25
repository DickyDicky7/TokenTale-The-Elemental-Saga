using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class TrackingScreen : PanelContainer
{
	[Export]
	public MainCharacter Viewer { get; set; }
	public override void _Process(double delta)
	{
		base._Process(delta);
		if (IsInstanceValid(Viewer) is false)
		{
			this.ProcessMode = ProcessModeEnum.Disabled;
		}
	}
}
