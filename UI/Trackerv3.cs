using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class Trackerv3 : VBoxContainer
{
	[Export]
	public Label Title { get; set; }
	[Export]
	public HBoxContainer TrackUnitContainer { get; set; }
	[Export]
	public HBoxContainer TrackStatsContainer { get; set; }
}
