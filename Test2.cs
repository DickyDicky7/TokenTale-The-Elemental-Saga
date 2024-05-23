using Godot ;
using System;

namespace TokenTaleTheElementalSaga;

public partial class Test2 : Node3D
{
    [Export]
    public MapSystem
           MapSystem
    {
        get;
        set;
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        GetWindow().Title =
          $"{Engine.GetFramesPerSecond()} {MapSystem.GetChild(0).GetChild(0).Name}";

    }
}
