using Godot ;
using System;

namespace    TokenTaleTheElementalSaga ;

public partial class _CharacterBody3D_ : CharacterBody3D
{
    public const float Speed        = 5.0f;
    public const float JumpVelocity = 4.5f;

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        Vector3
        velocity =
        Velocity ;

        if (!IsOnFloor())
        {
        velocity += GetGravity() * (float)@delta;
        }

        if (
Input.IsActionJustPressed("ui_accept")
        &&   IsOnFloor())
        {
        velocity.Y = JumpVelocity;
        }

        Vector2 inputDirection = Input.GetVector("L", "R", "U", "D");
        Vector3 direction = (Transform.Basis
*   new Vector3(inputDirection.X, 0.0f,
                inputDirection.Y)    ).                 Normalized();
        if (direction != Vector3.Zero)
        {
            velocity.X = direction.X * Speed;
            velocity.Z = direction.Z * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0.0f, Speed);
            velocity.Z = Mathf.MoveToward(Velocity.Z, 0.0f, Speed);
        }

        Velocity =
        velocity ;

        MoveAndSlide();
    }
}
