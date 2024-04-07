using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterSafe : State
{
    [Export]
    [ExportGroup("Components @@")]
    public EyeSight3D
           EyeSight3D
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Parameters !!")]
    public Vector2 SeeingDirection { get; set; }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        SeeingDirection = MainCharacter.GetScreenMousePosition();
        EyeSight3D
        .FollowPosition(
        SeeingDirection);
    }
}
