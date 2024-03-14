using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterMove : StateMainCharacter
{
    [Export]
    [ExportGroup("Transition To")]
    public State IdleState { get; set; }

    [Export]
    [ExportGroup("Transition To")]
    public State DashState { get; set; }

    public override void _Enter()
    {
                    base._Enter();
        MainCharacter.AnimationTree.Set("parameters/STATE/transition_request", "MOVE");
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.Space)
            {
                ChangeState(DashState);
            }
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        Vector2 @velocity = MainCharacter.Velocity;
        Vector2 direction =
        Input.GetVector
        ("L", "R", "U", "D");

        MainCharacter.BlendPosition = direction.Normalized();
        MainCharacter.AnimationTree.Set("parameters/BS2D_MOVE/blend_position", MainCharacter.BlendPosition);

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * MainCharacter.Speed;
            velocity.Y = direction.Y * MainCharacter.Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(MainCharacter.Velocity.X, 0, MainCharacter.Speed);
            velocity.Y = Mathf.MoveToward(MainCharacter.Velocity.Y, 0, MainCharacter.Speed);
            ChangeState(IdleState);
        }

        MainCharacter.Velocity = velocity;
        MainCharacter.MoveAndSlide();
    }
}
