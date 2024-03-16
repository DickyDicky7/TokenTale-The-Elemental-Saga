using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterSafe : State
{
    [Export]
    [ExportGroup("Components @@")]
    public EyeSight
           EyeSight
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

        SeeingDirection = MainCharacter.GetLocalMousePosition();
        EyeSight
        .FollowPosition(
        SeeingDirection);
    }
}
