using Godot;
using GodotStateCharts;
using TokenTaleTheElementalSaga.GameObjects.Shared;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacterV3 : CharacterBody2D
{
    [Export] public float JumpV { get; set; }
    [Export] public float Speed { get; set; }
    [Export] public EyeSight
                    EyeSight       { get; set; }
    [Export] public AnimationTree
                    AnimationTree  { get; set; }
    [Export] public Node NodeStateChart { get => null; set => _stateChart = StateChart.Of(value); }

    private Vector2    _cdirection;
    private StateChart _stateChart;


    #region SAFE STATE
    private void OnSafeStatePhysicsProcessing(float @delta)
    {
        EyeSight.FollowPosition(GetLocalMousePosition());
    }
    #endregion


    #region IDLE STATE
    private void OnIdleStateEntered()
    {
        AnimationTree.Set("parameters/STATE/transition_request", "IDLE");
    }

    private void OnIdleStateInput(InputEvent @inputEvent)
    {
        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.W or Key.S or Key.A or Key.D)
            {
                _stateChart.SendEvent("ToMoveState");
            }
        }
    }

    private void OnIdleStatePhysicsProcessing(float @delta)
    {
        _cdirection =
        _cdirection
        .Lerp(GetLocalMousePosition(), 0.1f)
        .Normalized();
        AnimationTree.Set("parameters/BS2D_IDLE/blend_position", _cdirection);
    }
    #endregion


    #region MOVE STATE
    private void OnMoveStateEntered()
    {
        AnimationTree.Set("parameters/STATE/transition_request", "MOVE");
    }

    private void OnMoveStatePhysicsProcessing(float @delta)
    {
        Vector2 @velocity = Velocity;
        Vector2 direction = Input.GetVector("L", "R", "U", "D");
        
        _cdirection =
          direction
        .Normalized();
        AnimationTree.Set("parameters/BS2D_MOVE/blend_position", _cdirection);

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Y = direction.Y * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            _stateChart.SendEvent("ToIdleState");
        }

        Velocity =
        velocity ;

        MoveAndSlide();
    }
    #endregion
}
