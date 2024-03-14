using Godot;

namespace TokenTaleTheElementalSaga;

public partial class CommandChangeState : Command
{
    [Export]
    public State TransitionFromState { get; set; }
    [Export]
    public State TransitionTo__State { get; set; }

    public override void Execute()
    {
                    base.Execute();

        TransitionFromState
       .EmitSignal(State.SignalName.TransitionFromTo, TransitionFromState, TransitionTo__State);
    }
}
