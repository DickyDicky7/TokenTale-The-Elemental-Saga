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
    [ExportGroup("Transition ##")]
    public State DeadState { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter MainCharacter { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public AnimationTree AnimationTree { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public
    Node3D GroundDetector
    {
        get;
        set;
    }

    public RayCast3D
           RayCast3D
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Parameters @@")]
    public Vector3 MovingDirection { get; set; }

    [Export]
    [ExportGroup("Parameters @@")]
    public Vector2 SeeingDirection { get; set; }

    public override void _Enter()
    {
        base         .   _Enter();

        AnimationTree.Set
("parameters/STATE/transition_request", "MOVE");
        RayCast3D = GroundDetector.GetNode<
        RayCast3D>(nameof(
        RayCast3D )      );
        RayCast3D.AddExceptionRid(MainCharacter.GetRid());

        MainCharacter.HealthChange +=
        MainCharacter_HealthChange;
    }

    public override void _Leave()
    {
        base         .   _Leave();

        MainCharacter.HealthChange -=
        MainCharacter_HealthChange;
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

        SeeingDirection =
            Extension.GetInputDirection();
        AnimationTree.Set("parameters/BS2D_MOVE/blend_position", SeeingDirection.Normalized());
    }

    public override void _PhysicsProcess(double @delta)
    {
        base         .   _PhysicsProcess(       @delta);

        MovingDirection =
            Extension.GetInputDirection().               ConvertToTopDown();

        GroundDetector.Rotation          =
        GroundDetector.Rotation with { Y =
        MovingDirection                  .SignedAngleTo( Vector3.Right    ,
                                                         Vector3.@Down ) };
                RayCast3D.TargetPosition =
                RayCast3D.TargetPosition ;
                RayCast3D.ForceRaycastUpdate();
            if (RayCast3D.IsColliding       ())
            {
        MainCharacter.Move(MovingDirection
                     .Normalized(), @delta);
            }

        if (               MovingDirection
        .IsZero())
        {
            ChangeState(IdleState);
        }

    }

    private void MainCharacter_HealthChange(float @damage)
    {
        if (     MainCharacter.             CurrentHealth <= 0.0f)
        {
            ChangeState(DeadState);
        }
    }

}






























