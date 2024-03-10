using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public partial class Shield : Weapon
{
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

    #region RESET STATE
    private void OnResetStateEntered()
    {
        CollisionShape2D.SetDeferred("disabled", !false);
        _tween = CreateTween();
        _tween
        .SetLoops();
        _tween.TweenProperty(this, "position:y", Position.Y - 1.5f, 0.5d)
              .SetEase (Tween.      EaseType.InOut)
              .SetTrans(Tween.TransitionType.Cubic);
        _tween.TweenProperty(this, "position:y", Position.Y + 1.5f, 0.5d)
              .SetEase (Tween.      EaseType.InOut)
              .SetTrans(Tween.TransitionType.Cubic);
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
                _stateChart.SendEvent("ToGuardState");
            }
        }
    }
    #endregion


    #region GUARD STATE
    private void OnGuardStateEntered()
    {
        CollisionShape2D.SetDeferred("disabled",  false);
        _tween = CreateTween();
        _tween.TweenCallback(Callable.From(() => _stateChart.SendEvent("ToResetState")));

    }

    private void OnGuardStateExited_()
    {
        _tween.Clear();
    }
    #endregion
}
