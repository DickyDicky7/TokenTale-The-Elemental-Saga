using Godot;
using GodotStateCharts;

using     TokenTaleTheElementalSaga.GameObjects.Items.Hand;
using     TokenTaleTheElementalSaga.GameObjects.Items.Wood;
using     TokenTaleTheElementalSaga.GameObjects.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacter : CharacterBody2D
{
    [Export] public int Speed { get; set; }
    [Export] public AnimationTree AnimationTree { get; set; }
    [Export] public Node NodeStateChart { get => null; set => _stateChart = StateChart.Of(value); }
    [Export] public HFlippable HFlippable { get; set; }
    [Export] public EyeSight   EyeSight   { get; set; }
    [Export] public LHand LHand { get; set; }
    [Export] public RHand RHand { get; set; }
    [Export] public Arrow Arrow { get; set; }
    [Export] public Shield1   Shield1   { get; set; }
    [Export] public LongSword LongSword { get; set; }
    [Export] public WeaponManager WeaponManager { get; set; }

    private StateChart _stateChart;


    #region Root State
    private void OnRootStateEntered()
    {
        AnimationTree.Active = true;
        AnimationTree.Set("parameters/T_BODY_AND_HAND/transition_request", "ACT");
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
        AnimationTree.Set("parameters/T_BODY/transition_request", "BODY_IDLE");
    }

    private void OnAliveBodyMotionIdleStateInput(InputEvent @inputEvent)
    {
        if (@inputEvent is InputEventKey inputEventKey)
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
        AnimationTree.Set("parameters/T_BODY/transition_request", "BODY_MOVE");
    }

    private void OnAliveBodyMotionMoveStatePhysicsProcessing(float @delta)
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

        Transform = HFlippable.Flip(Transform, direction);
        Velocity  = velocity;

        MoveAndSlide();
    }
    #endregion


    #region Root -> Alive -> HandMotion -> NoCombat State
    private void OnAliveHandMotionNoCombatStateEntered()
    {
        LongSword.Reset();
        LongSword.Reparent(RHand);
        LongSword.Position = new Vector2(0.5f, 8.0f);
    }

    private void OnAliveHandMotionNoCombatStateInput(InputEvent @inputEvent)
    {
        if (@inputEvent is InputEventKey inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.Space)
            {
                _stateChart.SendEvent("ToAliveHandMotionDoCombatState");
            }
        }

        WeaponManager.GetInput(@inputEvent);
    }

    private void OnAliveHandMotionNoCombatStatePhysicsProcessing(float @delta)
    {
        EyeSight.FollowPosition(GetLocalMousePosition());
    }
    #endregion


    #region Root -> Alive -> HandMotion -> DoCombat State
    private void OnAliveHandMotionDoCombatStateEntered()
    {
        AnimationTree.Set("parameters/T_HAND/transition_request", "HAND_DEAD");
        LongSword.Reparent(this);
        LongSword.Wield();
        _stateChart.SendEvent("ToAliveHandMotionNoCombatState");
    }
    #endregion


    #region Root -> Alive -> HandMotion -> NoCombat -> Idle State
    private void OnAliveHandMotionNoCombatIdleStateEntered()
    {
        AnimationTree.Set("parameters/T_HAND/transition_request", "HAND_IDLE");
    }

    private void OnAliveHandMotionNoCombatIdleStatePhysicsProcessing(float @delta)
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
        AnimationTree.Set("parameters/T_HAND/transition_request", "HAND_MOVE");
    }

    private void OnAliveHandMotionNoCombatMoveStatePhysicsProcessing(float @delta)
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
