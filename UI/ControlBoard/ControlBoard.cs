using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ControlBoard : PanelContainer
{
	[Export]
	public Button ResumeButton { get; set; }
	[Export]
	public Button ExitButton { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.ResumeButton.Pressed += Resume;
		this.ExitButton.Pressed += Exit;
	}
	public void Resume()
	{
		this.Visible = false;
	}
	public void Exit()
	{
		GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://UI/StartScreen/StartScreen.tscn"));
	}
}
