using Godot;
using Godot.Collections;
using System;
namespace TokenTaleTheElementalSaga;
public partial class SceneManager : PanelContainer
{
	[Export]
	public PackedScene StartScreen { get; set; }
	[Export]
	public PackedScene CreditScreen { get; set; }
	[Export]
	public PackedScene GameScreen { get; set; }
	private Node CurrentScene { get; set; }
	private Dictionary<string, PackedScene> SceneDict { get; set; } = new();
	public override void _Ready()
	{
		base._Ready();
		SceneDict.Add("Start", StartScreen);
		SceneDict.Add("Credit", CreditScreen);
		SceneDict.Add("Game", GameScreen);
		CurrentScene = StartScreen.Instantiate();
		this.AddChild(CurrentScene);
	}

	public void ChangeScene(string scene)
	{
		Window root = this.GetTree().Root;
		Node nextScene = SceneDict[scene].Instantiate();
		root.AddChild(nextScene);
		root.RemoveChild(CurrentScene);
		CurrentScene = nextScene;
	}
}
