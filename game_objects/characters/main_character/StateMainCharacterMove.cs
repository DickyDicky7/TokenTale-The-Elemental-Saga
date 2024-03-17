using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterMove : State
{
    [Export]
    [ExportGroup("Transition ##")]
    public State IdleState { get; set; }

    [Export]
    [ExportGroup("Transition ##")]
    public State DashState { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter MainCharacter { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public AnimationTree AnimationTree { get; set; }

    [Export]
    [ExportGroup("Parameters @@")]
    public Vector2 MovingDirection { get; set; }

    [Export]
    [ExportGroup("Parameters @@")]
    public Vector2 SeeingDirection { get; set; }

    public override void _Enter()
    {
        base         .   _Enter();

        AnimationTree.Set
("parameters/STATE/transition_request", "MOVE");
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if ( @inputEvent.IsKeyboardPressed(Key.Space))
        {
             ChangeState(DashState);
        }
    }

    public override void        _Process(double @delta)
    {
        base         .          _Process(       @delta);

        SeeingDirection
              = Input.GetVector
        ( "L", "R", "U", "D" );
        AnimationTree.Set("parameters/BS2D_MOVE/blend_position", SeeingDirection.Normalized());
    }

    public override void _PhysicsProcess(double @delta)
    {
        base         .   _PhysicsProcess(       @delta);

        MovingDirection
              = Input.GetVector
        ( "L", "R", "U", "D" );
        MainCharacter.Move(MovingDirection.Normalized(), @delta);

        if (               MovingDirection
        .IsZero())
        {
            ChangeState(IdleState);
        }
    }
}
