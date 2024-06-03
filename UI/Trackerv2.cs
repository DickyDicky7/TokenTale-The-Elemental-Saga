using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class Trackerv2 : VBoxContainer
{
	[Export]
	public Label Title { get; set; }
	[Export]
	public HBoxContainer TrackUnitContainer { get; set; }
	[Export]
	public HBoxContainer TrackLevelContainer { get; set; }
	[Export]
	public Label Prop { get; set; }
}
