using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public partial class BigBow : Weapon
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
        AnimatedSprite2D.Play("RESET");
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
                _stateChart.SendEvent("ToShootState");
            }
        }
    }
    #endregion


    #region SHOOT STATE
    private void OnShootStateEntered()
    {
        CollisionShape2D.SetDeferred("disabled",  false);
        _tween = CreateTween();
        _tween.TweenCallback(Callable.From(() => _stateChart.SendEvent("ToResetState")));

    }

    private void OnShootStateExited_()
    {
        _tween.Clear();
    }
    #endregion
}
