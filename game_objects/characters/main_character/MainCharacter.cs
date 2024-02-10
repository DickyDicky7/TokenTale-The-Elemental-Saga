using Godot;
using GodotStateCharts;

using     TokenTaleTheElementalSaga.GameObjects.Items.Hand;
using     TokenTaleTheElementalSaga.GameObjects.Items.Wood;
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
    private EyeSight _eyeSight;
    private LHand _lHand;
    private RHand _rHand;
    private Shield1 _shield1;
    private LongSword _longSword;

    public override void _Ready()
    {
        _lHand = GetNode<LHand>(nameof(LHand));
        _rHand = GetNode<RHand>(nameof(RHand));
        _eyeSight   = GetNode<EyeSight  >(nameof(EyeSight  ));
        _hFlippable = GetNode<HFlippable>(nameof(HFlippable));
        _stateChart = StateChart.Of(GetNode<Node>(nameof(StateChart  )));
        _animationTree =   GetNode<AnimationTree>(nameof(AnimationTree));

        _shield1   = _rHand.GetNode<Shield1  >(nameof(Shield1  ));
        _longSword = _rHand.GetNode<LongSword>(nameof(LongSword));
    }


    #region Root State
    private void OnRootStateEntered()
    {
        _animationTree.Active = true;
        _animationTree.Set("parameters/T_BODY_AND_HAND/transition_request", "ACT");
    }
    #endregion


    #region Root -> Alive State
    private void OnAliveStateEntered()
    {

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
    private void OnAliveHandMotionNoCombatStateEntered()
    {
        _longSword.Reset();
        _longSword.Reparent(_rHand);
        _longSword.Position = new Vector2(0.5f, 8.0f);
    }

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

    private void OnAliveHandMotionNoCombatStatePhysicsProcessing(float _delta_)
    {
        _eyeSight.FollowPosition(GetLocalMousePosition());
    }
    #endregion


    #region Root -> Alive -> HandMotion -> DoCombat State
    private void OnAliveHandMotionDoCombatStateEntered()
    {
        _animationTree.Set("parameters/T_HAND/transition_request", "HAND_DEAD");
        _longSword.Reparent(this);
        _longSword.Slash();
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


    #region Root -> Dead State
    private void OnDeadStateEntered()
    {


    }
    #endregion
}
