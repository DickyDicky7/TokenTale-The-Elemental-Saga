using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterIdle : StateMainCharacter
{
    [Export]
    [ExportGroup("Transition To")]
    public State MoveState { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        MainCharacter.AnimationTree.Set("parameters/STATE/transition_request", "IDLE");
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if (MainCharacter
                        . InputController.ShouldMove)
        {
            ChangeState(MoveState);
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        MainCharacter.Stop         (  MainCharacter.InputController.MovingDirection2D.Normalized());
        MainCharacter.BlendPosition = MainCharacter.InputController.SeeingDirection2D.Normalized() ;
        MainCharacter.AnimationTree.
        Set("parameters/BS2D_IDLE/blend_position",
        MainCharacter.BlendPosition);
    }
}
