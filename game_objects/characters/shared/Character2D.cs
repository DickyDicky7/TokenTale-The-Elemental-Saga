using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character2D : CharacterBody2D
{
    [Export]
    public float Speed { get; set; }
    [Export]
    public float Jumpv { get; set; }
    [Export]
    public float Acceleration { get; set; }
    [Export]
    public float Deceleration { get; set; }

    public virtual void Move(Vector2 @direction, double @delta)
    {
        if (@direction !=
            Vector2.Zero)
        {
            Vector2
            velocity = Velocity;

            velocity = velocity. MoveToward  (
            @direction *  Speed, Acceleration);

            Velocity = velocity;

            MoveAndSlide();
        }
    }

    public virtual void Stop(Vector2 @direction, double @delta)
    {
        if (@direction ==
            Vector2.Zero)
        {
            Vector2
            velocity =
            Velocity ;

            velocity = velocity. MoveToward  (
            @direction *  Speed, Deceleration);

            Velocity =
            velocity ;

            MoveAndSlide();
        }
    }

    public virtual void Dash(Vector2 @direction)
    {

    }
}
