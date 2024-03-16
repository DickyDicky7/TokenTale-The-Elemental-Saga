using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class State : Node
{
    public State() : base()
    {
    }

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode = ProcessModeEnum.Disabled;
    }

    public virtual void _Enter()
    {
    }

    public virtual void _Leave()
    {
    }

    public virtual void ChangeState
                             (State @newState)
    {
        EmitSignal(SignalName.TransitionFromTo, this,
                                    @newState);
    }

    [Signal]
    public delegate void TransitionFromToEventHandler(State @oldState, State @newState);
}
