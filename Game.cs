using Godot ;
using System;

namespace TokenTaleTheElementalSaga;

public partial class Game : Node3D
{
    [Export]
    public MapSystem
           MapSystem
    {
        get;
        set;
    }
    [Export]
    public SceneManager SceneManager { get; set; }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        //GetWindow().Title =
        //  $"{Engine.GetFramesPerSecond()} {MapSystem.GetChild(0).GetChild(0).Name}";

    }
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
        if (@event is InputEventKey inputEventKey)
        {
            if (inputEventKey.Pressed)
            {
                if (inputEventKey.Keycode == Key.Escape)
                {
                    SceneManager.ChangeScene("Start");
                }
            }
        }
	}
}
