using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood;

public partial class Quiver : Sprite2D
{
    private AnimationPlayer _animationPlayer;
    private StateChart _stateChart;
    private bool  _isEmpty = false;

    [Export]
    public bool IsEmpty
    {
        get => _isEmpty;
        set
        {
            _isEmpty = value;
            EmitSignal(SignalName.IsEmptyChanged, value);
        }
    }

    [Signal]
    public delegate void IsEmptyChangedEventHandler(bool _isEmpty_);

    public override void _Ready()
    {
        _animationPlayer =               GetNode<AnimationPlayer>(nameof(AnimationPlayer ));
        _stateChart      = StateChart.Of(GetNode<Node           >(nameof(StateChart     )));
        ChangeState();
    }

    private void OnIsEmptyChanged(bool _)
    {
        ChangeState();
    }

    private void ChangeState()
    {
        if (_isEmpty)
        {
            _stateChart.SendEvent("Event_IsEmptyT");
        }
        else
        {
            _stateChart.SendEvent("Event_IsEmptyF");

        }
    }

    private void OnNewOfArrowsStateEntered()
    {
        _animationPlayer.Play("NEW_OF_ARROWS");
    }

    private void OnOutOfArrowsStateEntered()
    {
        _animationPlayer.Play("OUT_OF_ARROWS");
    }
}
