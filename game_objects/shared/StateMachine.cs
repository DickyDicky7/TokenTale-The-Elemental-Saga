using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StateMachine : Node
{
    [Export]
    public Array<State>
           ActiveStates { get; set; }

    public override void _Ready()
    {
                    base._Ready();

        foreach (State state in ActiveStates)
        {
            state.TransitionFromTo +=
            State_TransitionFromTo
            ;
            state._Enter();
        }
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        foreach (State state in ActiveStates)
        {
                       state
                        ._Input(           @inputEvent);
        }
    }

    public override void        _Process(double @delta)
    {
                    base.       _Process(       @delta);

        foreach (State state in ActiveStates)
        {
                       state
                        .       _Process(       @delta);
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        foreach (State state in ActiveStates)
        {
                       state
                        ._PhysicsProcess(       @delta);
        }
    }

    protected virtual void State_TransitionFromTo(
        State @oldState                          ,
        State @newState                          )
    {
        ActiveStates.Remove(@oldState);
          @oldState .TransitionFromTo -= State_TransitionFromTo;
          @oldState ._Leave();
          @newState .TransitionFromTo += State_TransitionFromTo;
          @newState ._Enter();
        ActiveStates.Insert(@newState);
    }
}
