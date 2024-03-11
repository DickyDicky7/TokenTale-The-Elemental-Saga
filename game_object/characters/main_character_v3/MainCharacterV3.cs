using Godot;
using GodotStateCharts;

using     TokenTaleTheElementalSaga.GameObjects.Shared    ;
namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacterV3 : CharacterBody2D
{
    [Export] public float JumpV   { get; set; }
    [Export] public float Speed   { get; set; }
    [Export] public EyeSight
                    EyeSight                    { get; set; }
    [Export] public AnimationTree AnimationTree { get; set; }
    [Export] public Node NodeStateChart { get => null; set => _stateChart = StateChart.Of(value); }

    private
    Vector2 _blendPosition;
    private Tween      _tween     ;
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

    private void OnIdleState_Input_(InputEvent @inputEvent)
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
        _blendPosition =
        _blendPosition
        .Lerp(GetLocalMousePosition(), 0.1f)
        .Normalized();
        AnimationTree.Set("parameters/BS2D_IDLE/blend_position", _blendPosition);
    }
    #endregion


    #region MOVE STATE
    private void OnMoveStateEntered()
    {
        AnimationTree.Set("parameters/STATE/transition_request", "MOVE");
    }

    private void OnMoveState_Input_(InputEvent @inputEvent)
    {
        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode
            is            Key.Space  )
            {
                _stateChart.SendEvent("ToDashState");
            }
        }
    }

    private void OnMoveStatePhysicsProcessing(float @delta)
    {
        Vector2 @velocity = Velocity;
        Vector2 direction = Input.GetVector("L", "R", "U", "D");
        
        _blendPosition =
             direction
        .Normalized();
        AnimationTree.Set("parameters/BS2D_MOVE/blend_position", _blendPosition);

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Y = direction.Y * Speed;
            //velocity = velocity.Lerp(direction * Speed, 0.5f);
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            //velocity = velocity.Lerp(direction * Speed, 0.1f);
            _stateChart.SendEvent("ToIdleState");
        }

        Velocity =
        velocity ;

        MoveAndSlide();
    }
    #endregion


    #region DASH STATE
    private void OnDashStateEntered()
    {
        _tween = CreateTween();
        _tween.TweenProperty(this, "position", Position + _blendPosition * Speed, 0.5d)
              .SetEase (Tween.      EaseType. Out)
              .SetTrans(Tween.TransitionType.Circ);
        _tween.TweenCallback(Callable
              .From(() => _stateChart.SendEvent("ToMoveState")));
    }


    private void OnDashStateExited_()
    {
        _tween.Clear();
    }
    #endregion


}
