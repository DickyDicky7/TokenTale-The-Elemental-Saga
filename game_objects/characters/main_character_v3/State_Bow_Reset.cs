using Godot;

namespace TokenTaleTheElementalSaga;

public partial class State_Bow_Reset : State_Bow_
{
    [Export]
    [ExportGroup("Transition To")]
    public State ShootState { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        _Bow_.IsInUse = false;
        _Bow_.AnimatedSprite2D__Main.Play("RESET");
        _Bow_.CollisionShape2D.SetDeferred("disabled", true);
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if ( @inputEvent.IsLMousePressed())
        {
             ChangeState(ShootState);
        }
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        Vector2 hover_Position =     _Bow_.GetLocalMousePosition();
        Vector2 inputDirection = Extension.
             GetInputDirection();
        if (inputDirection !=
        Vector2.Zero)
        {
            hover_Position  =
            inputDirection  ;
        }

        _Bow_.CurrentRotationPosition = _Bow_.CurrentRotationPosition.Lerp(hover_Position, 0.1f);
        _Bow_.AnimatedSprite2D__Main.Rotation = _Bow_.CurrentRotationPosition.Angle() - Mathf.Pi / 2;
        _Bow_.CollisionShape2D.Rotation       = _Bow_.CurrentRotationPosition.Angle() - Mathf.Pi / 2;
        _Bow_.AnimatedSprite2DEffect.Rotation = _Bow_.CurrentRotationPosition.Angle() - Mathf.Pi;

        if (_Bow_.CurrentRotationPosition.Angle() <= -Mathf.Pi * 1 / 4
        &&  _Bow_.CurrentRotationPosition.Angle() >= -Mathf.Pi * 3 / 4)
        {
            _Bow_.ZIndex = -1;
        }
        else
        {
            _Bow_.ZIndex = +1;
        }

        if (_Bow_.CurrentRotationPosition.X < 0)
        {
            _Bow_.AnimatedSprite2D__Main.FlipH = !false;
        }
        else
        {
            _Bow_.AnimatedSprite2D__Main.FlipH =  false;
        }
    }
}
