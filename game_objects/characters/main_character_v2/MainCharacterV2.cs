using Godot;
using GodotStateCharts;

using     TokenTaleTheElementalSaga.GameObjects.Shared    ;
namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacterV2 : CharacterBody2D
{
    [Export] public float JumpV { get; set; }
    [Export] public float Speed { get; set; }
    [Export] public AnimationPlayer
                    AnimationPlayer { get; set; }
    [Export] public EyeSight
                    EyeSight        { get; set; }
    [Export] public HFlippable
                    HFlippable      { get; set; }
    [Export] public CollisionShape2D   CollisionShape2DBody      { get; set; }
    [Export] public CollisionShape2D   CollisionShape2DFeet      { get; set; }
    [Export] public CollisionPolygon2D CollisionPolygon2DHurtbox { get; set; }
    [Export] public Node NodeStateChart { get => null; set => _stateChart = StateChart.Of(value); }

    private byte       _slashCount;
    private StateChart _stateChart;


    #region Root -> Live -> NoCombat State
    private void OnNoCombatStateInput(InputEvent @inputEvent)
    {
        CollisionPolygon2DHurtbox
       .SetDeferred("disabled", true);

        if (@inputEvent is InputEventMouseButton  inputEventMouseButton)
        {
            if (inputEventMouseButton.Pressed)
            {
                switch (inputEventMouseButton.ButtonIndex)
                {
                    case MouseButton.Left :
                         _stateChart.SendEvent("ToSlashState");
                         break;

                    case MouseButton.Right:
                         _stateChart.SendEvent("ToShootState");
                         break;

                    case MouseButton.WheelDown:
                         _stateChart.SendEvent("ToGuardState");
                         break;
                }
            }
        }
        else
        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.Q)
            {
                _stateChart.SendEvent("ToDeadState");
            }
            else
            if (inputEventKey.Pressed
            &&  inputEventKey.Keycode is Key.E)
            {
                _stateChart.SendEvent("ToHurtState");
            }
        }
    }

    private void OnNoCombatStatePhysicsProcessing(float @delta)
    {
        EyeSight.FollowPosition(GetLocalMousePosition());
    }
    #endregion


    #region Root -> Live -> NoCombat -> Idle State
    private void OnIdleStateEntered()
    {
        AnimationPlayer.Play("IDLE");
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
    #endregion


    #region Root -> Live -> NoCombat -> Move State
    private void OnMoveStateEntered()
    {
        AnimationPlayer.Play("MOVE_D");
    }

    private void OnMoveStatePhysicsProcessing(float @delta)
    {
        Vector2 @velocity = Velocity;
        Vector2 direction = Input.GetVector("L", "R", "U", "D");

        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Y = direction.Y * Speed;
            if (direction.Y < 0)
            {
                if (AnimationPlayer.CurrentAnimation is "MOVE_D")
                {
                    AnimationPlayer.Play("MOVE_U");
                }
            }
            else
            {
                if (AnimationPlayer.CurrentAnimation is "MOVE_U")
                {
                    AnimationPlayer.Play("MOVE_D");
                }
            }
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
            _stateChart.SendEvent("ToIdleState");
        }

        Transform = HFlippable.Flip(Transform, direction);
        Velocity
      = velocity;

        MoveAndSlide();
    }
    #endregion


    #region Root -> Live -> InCombat -> Slash State
    private void OnSlashStateEntered()
    {
        CollisionPolygon2DHurtbox
       .SetDeferred("disabled", false);
        AnimationPlayer.Play($"SLASH_{_slashCount}");
        _slashCount += 1;
        _slashCount %= 3;
    }
    #endregion


    #region Root -> Live -> InCombat -> Shoot State
    private void OnShootStateEntered()
    {
        AnimationPlayer.Play("SHOOT");
    }
    #endregion


    #region Root -> Live -> InCombat -> Guard State
    private void OnGuardStateEntered()
    {
        AnimationPlayer.Play("GUARD");
    }
    #endregion


    private void OnAnimationPlayerAnimationCease(StringName @animationName)
    {
        if (@animationName == "SLASH_0"
        ||  @animationName == "SLASH_1"
        ||  @animationName == "SLASH_2"
        ||  @animationName == "SHOOT"
        ||  @animationName == "GUARD"
        ||  @animationName == "HURT")
        {
            _stateChart.SendEvent("ToMoveState");
        }
    }


    #region Root -> Hurt State
    private void OnHurtStateEntered()
    {
        AnimationPlayer.Play("HURT");
    }
    #endregion


    #region Root -> Dead State
    private void OnDeadStateEntered()
    {
        AnimationPlayer.Play("DEAD");
    }
    #endregion
}
