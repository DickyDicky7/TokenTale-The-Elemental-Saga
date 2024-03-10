using Godot;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood  ;

public partial class Quiver : BaseItem
{
    private bool _isEmpty = false;

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
    [Export] Arrow Arrow1 { get; set; }
    [Export] Arrow Arrow2 { get; set; }
    [Export] Arrow Arrow3 { get; set; }

    [Signal]
    public delegate void IsEmptyChangedEventHandler(bool @isEmpty);

    public override void _Ready()
    {
        Arrow1.CollisionShape2DHitbox.SetDeferred("disabled", true);
        Arrow2.CollisionShape2DHitbox.SetDeferred("disabled", true);
        Arrow3.CollisionShape2DHitbox.SetDeferred("disabled", true);
        //ChangeState();
    }

    private void OnIsEmptyChanged(bool @isEmpty)
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

    public override void Wield()
    {
        throw new System.NotImplementedException();
    }

    private void OnNewOfArrowsStateEntered()
    {
        AnimationPlayer.Play("NEW_OF_ARROWS");
    }

    private void OnOutOfArrowsStateEntered()
    {
        AnimationPlayer.Play("OUT_OF_ARROWS");
    }
}
