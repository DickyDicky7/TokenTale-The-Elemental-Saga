using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterIdle : State
{
    [Export]
    [ExportGroup("Transition ##")]
    public State MoveState { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter MainCharacter { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public AnimationTree AnimationTree { get; set; }

    public Vector3 MovingDirection { get; set; }
    public Vector2 SeeingDirection { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        AnimationTree.Set
("parameters/STATE/transition_request", "IDLE");
    }

    public override void        _Process(double @delta)
    {
                    base.       _Process(       @delta);

        SeeingDirection =
        MainCharacter.Get_LocalMousePosition().ConvertToTopDown();
//      SeeingDirection =
//      MainCharacter.GetScreenMousePosition()                   ;
        AnimationTree.Set("parameters/BS2D_IDLE/blend_position", SeeingDirection.Normalized());
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        MovingDirection =
            Extension.GetInputDirection() .ConvertToTopDown   ();
        MainCharacter.Stop(MovingDirection.Normalized(), @delta);

        if (!              MovingDirection.
        IsZero())
        {
            ChangeState(MoveState);
        }
    }
}
