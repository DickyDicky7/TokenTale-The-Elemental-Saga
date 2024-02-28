using Godot;
using GodotStateCharts;

using     TokenTaleTheElementalSaga.GameObjects.Items.Hand;
using     TokenTaleTheElementalSaga.GameObjects.Items.Wood;
using     TokenTaleTheElementalSaga.GameObjects.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacter : CharacterBody2D
{
    [Export] public float JumpV { get; set; }
    [Export] public float Speed { get; set; }
    [Export] public EyeSight     EyeSight { get; set; }
    [Export] public HFlippable HFlippable { get; set; }
    [Export] public AnimationTree AnimationTree { get; set; }
    [Export] public Node NodeStateChart { get => null; set => _stateChart = StateChart.Of(value); }
    [Export] public WeaponManagerMainCharacter WeaponManagerMainCharacter { get; set; }

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

    private void OnAliveStateInput(InputEvent @inputEvent)
    {
        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.Space)
            {
                Tween tween = CreateTween();
                tween.TweenProperty(this, "position:y", Position.Y + JumpV, 0.5f)
                     .SetEase (Tween.EaseType.Out)
                     .SetTrans(Tween.TransitionType.Expo);
                tween.TweenProperty(this, "position:y", Position.Y        , 0.5f)
                     .SetEase (Tween.EaseType.In )
                     .SetTrans(Tween.TransitionType.Expo);
            }
        }
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
            &&  inputEventKey.Keycode is Key.W or Key.S or Key.A or Key.D)
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
        Velocity
      = velocity;

        MoveAndSlide();
    }
    #endregion

    private void OnWeaponManagerMainCharacterWieldCurrentWeaponCease()
    {
        _stateChart.SendEvent("ToAliveHandMotionNoCombatState");
        WeaponManagerMainCharacter .ResetCurrentWeapon();
    }


    #region Root -> Alive -> HandMotion -> NoCombat State
    private void OnAliveHandMotionNoCombatStateEntered()
    {

    }

    private void OnAliveHandMotionNoCombatStateInput(InputEvent @inputEvent)
    {
        if (@inputEvent is InputEventMouseButton inputEventMouseButton)
        {
            if (inputEventMouseButton.Pressed
            &&  inputEventMouseButton.ButtonIndex is MouseButton.Left )
            {
                _stateChart.SendEvent("ToAliveHandMotionDoCombatState");
                return;
            }
        }

        WeaponManagerMainCharacter
       .HandleInputSwitchCurrentWeapon(@inputEvent);
    }

    private void OnAliveHandMotionNoCombatStatePhysicsProcessing(float @delta)
    {
        EyeSight.FollowPosition(GetLocalMousePosition());
    }
    #endregion


    #region Root -> Alive -> HandMotion -> DoCombat State
    private void OnAliveHandMotionDoCombatStateEntered()
    {
        WeaponManagerMainCharacter .WieldCurrentWeapon();
        AnimationTree.Set("parameters/T_HAND/transition_request", "HAND_DEAD");
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
