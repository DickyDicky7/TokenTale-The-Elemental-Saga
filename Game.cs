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
    public AudioStream
           BGM
    {
        get;
        set;
    }
    public override void _Ready()
    {
                    base._Ready();

        GetNode<SoundManagerBGM_______>  (
$"/root/{nameof(SoundManagerBGM_______)}").CrossfadeTo(BGM);

    }
    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        //GetWindow().Title =
        //  $"{Engine.GetFramesPerSecond()} {MapSystem.GetChild(0).GetChild(0).Name}";

    }
}

