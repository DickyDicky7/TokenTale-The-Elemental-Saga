using Godot;
using System;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

public partial class MainCharacter : CharacterBody2D
{
    [Export]
    public int Speed { get; set; } = 100;

    private AnimationTree _animationTree;
    private readonly HFlippable _hFlippable = new();

    public override void _Ready()
    {
        _animationTree = GetNode<AnimationTree>(nameof(AnimationTree));
        _animationTree.Active = true;
        _animationTree.Set("parameters/T_BODY_AND_HAND/transition_request", "ACT");
    }

    bool b = false;

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        //if (!IsOnFloor())
        //    velocity.Y += gravity * (float)delta;

        // Handle Jump.
        //if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
        //    velocity.Y = JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Y = direction.Y * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        }



        Transform = _hFlippable.Flip(Transform, direction);

        Velocity = velocity;
        MoveAndSlide();
    }
}
