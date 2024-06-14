using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class StartScreen : PanelContainer
{
	[Export]
	public Button StartButton { get; set; }
	[Export]
	public Button SandBoxButton { get; set; }
	[Export]
	public Button CreditButton { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.CreditButton.Pressed += SwitchToCredit;
		this.StartButton.Pressed += SwitchToGame;
		this.SandBoxButton.Pressed += SwitchToSandBox;
	}
	private void SwitchToCredit()
	{
		GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://UI/Credit/CreditScreen.tscn"));
	}
	private void SwitchToGame()
	{
		GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://Game.tscn"));
	}
	private void SwitchToSandBox()
	{
		GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://Main.tscn"));
	}
}
