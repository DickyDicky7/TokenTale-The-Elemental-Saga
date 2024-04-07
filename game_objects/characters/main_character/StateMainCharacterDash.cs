using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterDash : State
{
    [Export]
    [ExportGroup("Transition ##")]
    public State MoveState { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }

    private Tween _tween;

    public override void _Enter()
    {
                    base._Enter();

        Vector3 blendPosition =  Extension.GetInputDirection().ConvertToTopDown();
        _tween = MainCharacter.CreateTween();
        _tween.TweenProperty(MainCharacter, "position"
                           , MainCharacter.     Position
                           +               blendPosition
                           * MainCharacter.Speed  ,0.5d)
              .SetEase (Tween.      EaseType. Out)
              .SetTrans(Tween.TransitionType.Circ);
        _tween.TweenCallback(Callable
              .From(() => ChangeState(MoveState)));
    }

    public override void _Leave()
    {
                    base._Leave();

        _tween.Clear();
    }
}
