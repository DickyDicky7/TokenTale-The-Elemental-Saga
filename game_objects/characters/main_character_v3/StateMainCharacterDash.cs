using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterDash : StateMainCharacter
{
    [Export]
    [ExportGroup("Transition To")]
    public State MoveState { get; set; }

    private Tween _tween;

    public override void _Enter()
    {
                    base._Enter();

        _tween = MainCharacter.CreateTween();
        _tween.TweenProperty(MainCharacter, "position"
                           , MainCharacter.     Position
                           + MainCharacter.BlendPosition
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
