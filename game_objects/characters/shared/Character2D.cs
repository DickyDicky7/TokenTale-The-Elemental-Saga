using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character2D : CharacterBody2D
{
    [Export]
    public float Speed { get; set; }
    [Export]
    public float Jumpv { get; set; }

    public virtual void Move(Vector2 @direction)
    {
        Vector2
        velocity =
        Velocity ;

        if (@direction
        !=
        Vector2.Zero)
        {
            velocity.X = @direction.X * Speed;
            velocity.Y = @direction.Y * Speed;
        }

        Velocity =
        velocity ;

        MoveAndSlide();
    }

    public virtual void Stop(Vector2 @direction)
    {
        Vector2
        velocity =
        Velocity ;

        if (@direction
        ==
        Vector2.Zero)
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
            velocity.Y = Mathf.MoveToward(Velocity.Y, 0, Speed);
        }

        Velocity =
        velocity ;

        MoveAndSlide();
    }

    public virtual void Dash(Vector2 @direction)
    {

    }
}
