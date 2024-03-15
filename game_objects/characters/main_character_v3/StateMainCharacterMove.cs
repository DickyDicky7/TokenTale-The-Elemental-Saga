using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterMove : StateMainCharacter
{
    [Export]
    [ExportGroup("Transition To")]
    public State IdleState { get; set; }

    [Export]
    [ExportGroup("Transition To")]
    public State DashState { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        MainCharacter.AnimationTree.Set("parameters/STATE/transition_request", "MOVE");
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if ( MainCharacter
                        . InputController.ShouldDash)
        {
            ChangeState(DashState);
        }
        if (!MainCharacter
                        . InputController.ShouldMove)
        {
            ChangeState(IdleState);
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        MainCharacter.Move         (  MainCharacter.InputController.MovingDirection2D.Normalized());
        MainCharacter.BlendPosition = MainCharacter.InputController.MovingDirection2D.Normalized() ;
        MainCharacter.AnimationTree.
        Set("parameters/BS2D_MOVE/blend_position",
        MainCharacter.BlendPosition);
    }
}
