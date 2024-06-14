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
	private SceneManager SceneManager { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.CreditButton.Pressed += SwitchToCredit;
		this.StartButton.Pressed += SwitchToGame;
		this.SceneManager = GetNode<SceneManager>("/root/SceneManager");
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
