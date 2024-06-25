using Godot;

namespace TokenTaleTheElementalSaga;

public partial class State_Bow_Reset : State_Bow_
{
    [Export]
    [ExportGroup("Transition ##")]
    public State ShootState { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        _Bow_.IsInUse = false;
        _Bow_.AnimationPlayerr.Play       ("RESET"         );
        _Bow_.CollisionShape3D.SetDeferred("disabled", true);
    }

    public override void _Input(InputEvent @inputEvent)
    {
        
                    base._Input(           @inputEvent);
        if ( @inputEvent.IsMousePressed
           ( MouseButton.Left))
        {
			if (_Bow_.IsCoolingDown == true || _Bow_.OwnerMainCharacter.IsStunning == true)
				return;
			if (_Bow_.CurrentArrow == 0)
			{
				_Bow_.EmitSignal(_Bow_.SignalName.OutOfArrow);
				return;
			}
			ChangeState(ShootState);
        }
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        Vector2 hover_Position =     _Bow_.Get_LocalMousePosition().ConvertToTopDown();
//      Vector2 hover_Position =     _Bow_.GetScreenMousePosition()                   ;
        Vector2 inputDirection = Extension.
             GetInputDirection();
        if (inputDirection !=
        Vector2.Zero)
        {
            hover_Position  =
            inputDirection  ;
        }

        _Bow_.CurrentRotationPosition = _Bow_.CurrentRotationPosition.Lerp(hover_Position, 0.1f);
        _Bow_.AnimatedSprite3DMmainn.Rotation =
        _Bow_.AnimatedSprite3DMmainn.Rotation with { Z = -
        _Bow_.CurrentRotationPosition.Angle() + Mathf.Pi / 2.0f, };
        _Bow_.CollisionShape3D      .Rotation       =
        _Bow_.CollisionShape3D      .Rotation with { Y = -
        _Bow_.CurrentRotationPosition.Angle() + Mathf.Pi / 2.0f, };
        _Bow_.AnimatedSprite3DEffect.Rotation =
        _Bow_.AnimatedSprite3DEffect.Rotation with { Y = -
        _Bow_.CurrentRotationPosition.Angle() + Mathf.Pi       , };

        if (_Bow_.CurrentRotationPosition.Angle() <= -Mathf.Pi * 1.0f / 4.0f
        &&  _Bow_.CurrentRotationPosition.Angle() >= -Mathf.Pi * 3.0f / 4.0f)
        {
            int renderPriority = -1;
            _Bow_.AnimatedSprite3DMmainn.MaterialOverride.RenderPriority = renderPriority;
            _Bow_.AnimatedSprite3DEffect.MaterialOverride.RenderPriority = renderPriority;
        }
        else
        {
            int renderPriority = +1;
            _Bow_.AnimatedSprite3DMmainn.MaterialOverride.RenderPriority = renderPriority;
            _Bow_.AnimatedSprite3DEffect.MaterialOverride.RenderPriority = renderPriority;
        }

        if (_Bow_.CurrentRotationPosition.X < 0)
        {
            _Bow_.AnimatedSprite3DMmainn.FlipH = !false;
        }
        else
        {
            _Bow_.AnimatedSprite3DMmainn.FlipH =  false;
        }
    }
}









