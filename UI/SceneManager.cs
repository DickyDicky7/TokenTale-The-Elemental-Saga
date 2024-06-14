using Godot;
using Godot.Collections;
using System;
namespace TokenTaleTheElementalSaga;
public partial class SceneManager : PanelContainer
{
	public StartScreen StartScreen { get; set; }
	public Credit CreditScreen { get; set; }
	public Game GameScreen { get; set; }
	private Node CurrentScene { get; set; }
	private Dictionary<string, Node> SceneDict { get; set; } = new();
	public override void _Ready()
	{
		base._Ready();

		StartScreen = ResourceLoader.Load<PackedScene>("res://UI/StartScreen/StartScreen.tscn").Instantiate<StartScreen>();
		//CreditScreen = ResourceLoader.Load<PackedScene>("res://UI/Credit/Credit.tscn").Instantiate<Credit>();
		//GameScreen = ResourceLoader.Load<PackedScene>("res://Game.tscn").Instantiate<Game>();

		SceneDict.Add("Start", StartScreen);
		SceneDict.Add("Credit", CreditScreen);
		SceneDict.Add("Game", GameScreen);
		this.CurrentScene = StartScreen;
		this.AddChild(CurrentScene);

		GD.Print("CALL");
	}

	public void ChangeScene(string scene)
	{
		Window root = this.GetTree().Root;
		Node nextScene = SceneDict[scene];
		root.AddChild(nextScene);
		root.RemoveChild(CurrentScene);
		CurrentScene = nextScene;
	}
}
