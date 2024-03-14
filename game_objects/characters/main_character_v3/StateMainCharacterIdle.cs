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

        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode
            is  Key.W
            or  Key.S
            or  Key.A
            or  Key.D     )
            {
                ChangeState(MoveState);
            }
        }
    }
    

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        //Vector2 movingDirection2D =
        //MainCharacter.ParametersController2D.
        //        MovingDirection2D ;

        //if    ( movingDirection2D ==
        //Vector2.Zero)
        //{
        //    ChangeState(MoveState);
        //}

        MainCharacter.BlendPosition =
        MainCharacter.BlendPosition.Lerp(MainCharacter.GetLocalMousePosition(), 0.1f)
        .Normalized();
        MainCharacter.AnimationTree.
        Set("parameters/BS2D_IDLE/blend_position",
        MainCharacter.BlendPosition);
    }
}
