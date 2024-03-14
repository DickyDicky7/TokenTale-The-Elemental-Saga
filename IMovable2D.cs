//using Godot;
//using Godot.Collections;

//namespace TokenTaleTheElementalSaga;

//public abstract partial class StateControllerComponent : Node
//{
//    public StateControllerComponent() : base()
//    {
//        _subStates = [];
//    }

//    [Signal]
//    public delegate void OnStateChangedEventHandler(State @oldState, State @newState);

//    protected Array<State>  _subStates;
//    protected State _currentState;

//    public override void _Ready()
//    {
//                    base._Ready();
//        foreach (State subState in _subStates)
//        {
//            subState.ProcessMode = ProcessModeEnum.Disabled;
//        }
//        _currentState = _subStates[0];
//        _currentState.OnStateChanged += CurrentState_OnStateChanged;
//        _currentState.ProcessMode = ProcessModeEnum.Inherit;
//    }

//    private void CurrentState_OnStateChanged(State @oldState, State @newState)
//    {
//        throw new System.NotImplementedException();
        
//    }

//    public override void _Input(InputEvent @inputEvent)
//    {
//        base._Input(@inputEvent);

//    }
//}

//public partial class State : Node;

//public class StatesPool : Resource
//{
//    public Array<State> 
//}