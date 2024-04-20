using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character3D : CharacterBody3D
{
	[Export]
	public int Health { get; set; }
	[Export]
    public float Speed { get; set; }
    [Export]
    public float Jumpv { get; set; }
    [Export]
    public float Acceleration { get; set; }
    [Export]
    public float Deceleration { get; set; }

    public virtual void Move(Vector3 @direction, double @delta)
    {
            @direction  =   (         Transform.         Basis
        *   @direction).Normalized();

        if (@direction !=
            Vector3.Zero)
        {
            Vector3
            velocity = Velocity;

            velocity = velocity. MoveToward  (
            @direction *  Speed, Acceleration);

            //if (!IsOnFloor())
            //{
            //velocity+= GetGravity() * (float)delta * Speed;
            //}

            Velocity = velocity;

            MoveAndSlide();            
        }
    }

    public virtual void Stop(Vector3 @direction, double @delta)
    {
            @direction  =   (         Transform.         Basis
        *   @direction).Normalized();

        if (@direction ==
            Vector3.Zero)
        {
            Vector3
            velocity =
            Velocity ;

            velocity = velocity. MoveToward  (
            @direction *  Speed, Deceleration);

            //if (!IsOnFloor())
            //{
            //velocity+= GetGravity() * (float)delta * Speed;
            //}

            Velocity =
            velocity ;

            MoveAndSlide();
        }
    }

    public virtual void Dash(Vector3 @direction)
    {

    }
}
