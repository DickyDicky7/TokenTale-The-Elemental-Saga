using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public partial class BSword : Weapon
{
    [Export]
    public Sprite2D
           Sprite2D
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

    [Export] public Node NodeStateChart
    {
        get => null;
        set => _stateChart = StateChart.Of(value);
    }

    private Tween      _tween     ;
    private StateChart _stateChart;

    private void GuessBSwordRotation(Vector2 @position)
    {
        float angle    = Mathf.RadToDeg
            (@position.Angle());
        float rotation = angle switch
        {
            > -135.0f and <= +045.0f => Mathf.DegToRad(-45.0f),
            _                        => Mathf.DegToRad(+45.0f),
        };
        if  ( rotation != Sprite2D.Rotation)
        {
            Tween tween = CreateTween();
            tween.SetLoops(1);
            tween.TweenProperty(        Sprite2D, "rotation", rotation, 0.5d)
                 .SetEase (Tween.      EaseType.Out  )
                 .SetTrans(Tween.TransitionType.Quint);
            tween.Parallel( );
            tween.TweenProperty(CollisionShape2D, "rotation", rotation, 0.5d)
                 .SetEase (Tween.      EaseType.Out  )
                 .SetTrans(Tween.TransitionType.Quint);
        }
    }

    private void ResetBSwordRotation()
    {
                Sprite2D.Rotation = 0.0f;
        CollisionShape2D.Rotation = 0.0f;
    }


    #region RESET STATE
    private void OnResetStateEntered()
    {
        CollisionShape2D.SetDeferred("disabled", !false);
        _tween = CreateTween();
        _tween
        .SetLoops(0);
        _tween.TweenProperty(this, "position:y", Position.Y - 1.5f, 0.5d)
              .SetEase (Tween.      EaseType.InOut)
              .SetTrans(Tween.TransitionType.Cubic);
        _tween.TweenProperty(this, "position:y", Position.Y + 1.5f, 0.5d)
              .SetEase (Tween.      EaseType.InOut)
              .SetTrans(Tween.TransitionType.Cubic);
        GuessBSwordRotation (GetLocalMousePosition());
    }

    private void OnResetStateExited_()
    {
        _tween.Clear();
    }

    private void OnResetState_Input_(InputEvent @inputEvent)
    {
        if (@inputEvent is InputEventMouseButton inputEventMouseButton)
        {
            if (inputEventMouseButton.Pressed
            &&  inputEventMouseButton.ButtonIndex
            is            MouseButton.Left)
            {
                _stateChart.SendEvent("ToSlashState");
            }
        }
    }

    private void OnResetStatePhysicsProcessing(float @delta)
    {
        Vector2 direction =    Input.GetVector("L", "R", "U", "D");
        if    ( direction == Vector2.Zero)
        {
            GuessBSwordRotation(GetLocalMousePosition());
        }
        else
        {
            GuessBSwordRotation(              direction);
        }
    }
    #endregion


    #region SLASH STATE
    private void OnSlashStateEntered()
    {
         ResetBSwordRotation();
        CollisionShape2D.SetDeferred("disabled",  false);
        _tween = CreateTween();
        _tween.TweenCallback(Callable.From(() => _stateChart.SendEvent("ToResetState")));

    }

    private void OnSlashStateExited_()
    {
        _tween.Clear();
    }
    #endregion
}
