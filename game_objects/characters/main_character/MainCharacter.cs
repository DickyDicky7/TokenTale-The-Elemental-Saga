using Godot;
using GodotStateCharts;

using     TokenTaleTheElementalSaga.GameObjects.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacter : CharacterBody2D
{
    [Export]
    public int Speed { get; set; }

    private StringName _lastHandAnimation = null;
    private StateChart _stateChart;
    private HFlippable _hFlippable;
    private AnimationTree _animationTree;

    public override void _Ready()
    {
        _hFlippable = GetNode<HFlippable>(nameof(HFlippable));
        _stateChart = StateChart.Of(GetNode<Node>(nameof(StateChart  )));
        _animationTree =   GetNode<AnimationTree>(nameof(AnimationTree));
    }

    #region Root State
    private void OnRootStateEntered()
    {
        _animationTree.Active = true;
        _animationTree.Set("parameters/T_BODY_AND_HAND/transition_request", "ACT");
    }
    #endregion

    #region Root -> Alive -> BodyMotion -> Idle State
    private void OnAliveBodyMotionIdleStateEntered()
    {
        _animationTree.Set("parameters/T_BODY/transition_request", "BODY_IDLE");
    }

    private void OnAliveBodyMotionIdleStateInput(InputEvent _inputEvent_)
    {
        if (_inputEvent_ is InputEventKey inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.Up or Key.Down or Key.Left or Key.Right)
            {
                _stateChart.SendEvent("ToAliveBodyMotionMoveState");
            }
        }
    }
    #endregion

    #region Root -> Alive -> BodyMotion -> Move State
    private void OnAliveBodyMotionMoveStateEntered()
    {
        _animationTree.Set("parameters/T_BODY/transition_request", "BODY_MOVE");
    }

    private void OnAliveBodyMotionMoveStatePhysicsProcessing(float _delta_)
    {
        Vector2 velocity  = Velocity;
        Vector2 direction = Input.GetVector("L", "R", "U", "D");
        
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Y = direction.Y * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            _stateChart.SendEvent("ToAliveBodyMotionIdleState");
        }

        Transform = _hFlippable.Flip(Transform, direction);
        Velocity  = velocity;

        MoveAndSlide();
    }
    #endregion

    #region Root -> Alive -> HandMotion -> NoCombat State
    private void OnAliveHandMotionNoCombatStateInput(InputEvent _inputEvent_)
    {
        if (_inputEvent_ is InputEventKey inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.Space)
            {
                _stateChart.SendEvent("ToAliveHandMotionDoCombatState");
            }
        }
    }
    #endregion

    #region Root -> Alive -> HandMotion -> DoCombat State
    private void OnAliveHandMotionDoCombatStateEntered()
    {
        _animationTree.Set("parameters/T_HAND/transition_request", "HAND_DEAD");
        _stateChart.SendEvent("ToAliveHandMotionNoCombatState");
    }
    #endregion

    #region Root -> Alive -> HandMotion -> NoCombat -> Idle State
    private void OnAliveHandMotionNoCombatIdleStateEntered()
    {
        _animationTree.Set("parameters/T_HAND/transition_request", "HAND_IDLE");
    }

    private void OnAliveHandMotionNoCombatIdleStatePhysicsProcessing(float _delta_)
    {
        Vector2 direction = Input.GetVector("L", "R", "U", "D");
        if (direction  != Vector2.Zero)
        {
            _stateChart.SendEvent("ToAliveHandMotionNoCombatMoveState");
        }
    }
    #endregion

    #region Root -> Alive -> HandMotion -> NoCombat -> Move State
    private void OnAliveHandMotionNoCombatMoveStateEntered()
    {
        _animationTree.Set("parameters/T_HAND/transition_request", "HAND_MOVE");
    }

    private void OnAliveHandMotionNoCombatMoveStatePhysicsProcessing(float _delta_)
    {
        Vector2 direction = Input.GetVector("L", "R", "U", "D");
        if (direction  == Vector2.Zero)
        {
            _stateChart.SendEvent("ToAliveHandMotionNoCombatIdleState");
        }
    }
    #endregion
}
