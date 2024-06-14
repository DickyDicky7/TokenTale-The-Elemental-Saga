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
	[Export]
	public SceneManager SceneManager { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.CreditButton.Pressed += SwitchToCredit;
		this.StartButton.Pressed += SwitchToGame;
	}
	private void SwitchToCredit()
	{
		SceneManager.ChangeScene("Credit");
	}
	private void SwitchToGame()
	{
		SceneManager.ChangeScene("Game");
	}
}
