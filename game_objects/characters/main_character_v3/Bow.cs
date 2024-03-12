using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public partial class Bow : Weapon
{
    [Export]
    public AnimatedSprite2D
           AnimatedSprite2D
    {
        get;
        set;
    }

    [Export]
    public CollisionShape2D
           CollisionShape2D
    {
        get;
        set;
    }

    [Export]
    public AnimatedSprite2D
           AnimatedSprite2DEffect
    {
        get;
        set;
    }

    [Export] public Node NodeStateChart
    {
        get => null;
        set => _stateChart = StateChart.Of(value);
    }

    private Vector2    _currRotPos;
    private Tween      _tween1    ;
    private Tween      _tween2    ;
    private Tween      _tween3    ;
    private StateChart _stateChart;


    #region RESET STATE
    private void OnResetStateEntered()
    {
        AnimatedSprite2D.Play("RESET");
        CollisionShape2D.SetDeferred("disabled", !false);
    }

    private void OnResetStateExited_()
    {
        _tween1.Clear();
        _tween2.Clear();
        _tween3.Clear();
    }

    private void OnResetState_Input_(InputEvent @inputEvent)
    {
        if (   @inputEvent
        is      InputEventMouseButton
                inputEventMouseButton)
        {
            if (inputEventMouseButton
            .Pressed
            &&  inputEventMouseButton.ButtonIndex
            is            MouseButton.Left          )
            {
                _stateChart.SendEvent("ToShootState");
            }
        }
    }

    public void OnResetStatePhysicsProcessing(float @delta)
    {
        Vector2 toPos = GetLocalMousePosition();

        Vector2 direction
        = Input.GetVector( "L", "R", "U", "D" );


        if (direction != Vector2.Zero)
        {
            toPos =
            direction;
        }

        _currRotPos = _currRotPos.Lerp(toPos, 0.1f);
        AnimatedSprite2D.Rotation = _currRotPos.Angle() - Mathf.Pi / 2;
        CollisionShape2D.Rotation = _currRotPos.Angle() - Mathf.Pi / 2;
        AnimatedSprite2DEffect.Rotation = _currRotPos.Angle() - Mathf.Pi;

        if (_currRotPos.Angle() <= -Mathf.Pi * 1 / 4
        &&  _currRotPos.Angle() >= -Mathf.Pi * 3 / 4)
        {
            ZIndex = -1;
        }
        else
        {
            ZIndex = +1;
        }

        if (_currRotPos.X < 0)
        {
            AnimatedSprite2D.FlipH = !false;
        }
        else
        {
            AnimatedSprite2D.FlipH =  false;
        }
    }
    #endregion


    #region SHOOT STATE
    private void OnShootStateEntered()
    {
        AnimatedSprite2D.Play("SHOOT");
        CollisionShape2D.SetDeferred("disabled", !false);
    }

    private void OnShootStateExited_()
    {
        _tween1.Clear();
        _tween2.Clear();
        _tween3.Clear();
    }
    #endregion


    private void OnAnimatedSprite2D______AnimationCease()
    {
        if (AnimatedSprite2D
           .Animation == "SHOOT" )
        {
            AnimatedSprite2DEffect. Play("SHOOT");
        }
    }

    private void OnAnimatedSprite2DEffectAnimationCease()
    {
        if (AnimatedSprite2DEffect
           .Animation == "SHOOT"  )
        {
            AnimatedSprite2DEffect. Play("RESET");
            _stateChart.SendEvent("ToResetState");
        }
    }
}
