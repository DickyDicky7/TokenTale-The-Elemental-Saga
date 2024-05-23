using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character3D : CharacterBody3D
{
    public float CurrentHealth{ get; set; }
    public float MaxHealth { get; set; } = 1.0f;
    public float CurrentSpeed { get; set; }
    public float Speed { get; set; } = 1.0f;
    public float Jumpv { get; set; } = 1.0f;
    public float Acceleration { get; set; } = 0.1f;
    public float Deceleration { get; set; } = 0.1f;
    [Signal]
    public delegate void HealthChangeEventHandler(float Damage);

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
            @direction * CurrentSpeed, Acceleration);


            if (!IsOnFloor())
            {
            velocity+= GetGravity() * (float)delta * Jumpv;
            }

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
            @direction * CurrentSpeed, Deceleration);

            if (!IsOnFloor())
            {
            velocity+= GetGravity() * (float)delta * Jumpv;
            }

            Velocity =
            velocity ;

            MoveAndSlide();
        }
    }

    public virtual void Dash(Vector3 @direction)
    {

    }

	public override void _Ready()
	{
		            base._Ready();
	}
}






