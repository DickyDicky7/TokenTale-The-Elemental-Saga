using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character3D : CharacterBody3D
{

    [Export]
    public PackedScene StatusInfoPackedScene { get; set; }
    public float CurrentHealth { get; set; }
    public float     MaxHealth { get; set; } = 1.0f;
    public float CurrentSpeed  { get; set; }
    public float        Speed  { get; set; } = 1.0f;
    public float        Jumpv  { get; set; } = 1.0f;
    public float Acceleration  { get; set; } = 0.1f;
    public float Deceleration  { get; set; } = 0.1f;
    public Global.Element ElementMark { get; set; } = Global.Element.None;
    public Timer EffectTimer   { get; private set; } = new();
    public StatusInfo
           StatusInfo          { get; private set; }

    [Signal]
    public delegate void HealthChangeEventHandler(float damage);

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


            if (       !IsOnFloor() )
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

            if (       !IsOnFloor() )
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
        this.EffectTimer. OneShot = true;
        this.EffectTimer.WaitTime = 1.0d;
        this.EffectTimer.ProcessCallback = Timer.TimerProcessCallback.Physics;
        this.EffectTimer.ProcessMode     =            ProcessModeEnum. Always;
        this.AddChild   (EffectTimer, @internal: InternalMode.Back);
        this.StatusInfo = StatusInfoPackedScene.Instantiate<StatusInfo>();
        this.AddChild  (  StatusInfo                                    );
		base._Ready();
	}

    //  public override void _PhysicsProcess(double @delta)
    //  {
    //                  base._PhysicsProcess(       @delta);
    //
    //      if (!  IsOnFloor())
    //      {
    //          Velocity  =                                  new();
    //          Velocity += GetGravity() *  (float) @delta * Jumpv;
    //          MoveAndSlide();
    //      }
    //  }
    public abstract float CalculateDamage(Ability3D ability, Character3D target);

    public void StartSpeedEffect(float @ratio, float @duration)
    {
        this.CurrentSpeed =
        this.       Speed *            @ratio     ;
        this.EffectTimer.Timeout += EndSpeedEffect;
        this.EffectTimer.Start  (                    @duration);
    }

    public void   EndSpeedEffect()
    {
        this.EffectTimer.Stop   ();
        this.CurrentSpeed =
        this.       Speed ;
        this.EffectTimer.WaitTime     = 1.0f          ;
        this.EffectTimer.    Timeout -= EndSpeedEffect;
    }

    public void BePushed(Vector3 @velocity)
    {
        this.Velocity =          @velocity;
        this.MoveAndSlide();
        this.Velocity =  Vector3.Zero     ;
    }

    public void StartStun(float @duration)
    {
        this.EffectTimer.Timeout += EndStun;
        this.EffectTimer.Start( @duration) ;
        this.ProcessMode = ProcessModeEnum.Disabled;
    }

    public void   EndStun()
    {
        this.EffectTimer.Stop();
        this.EffectTimer.Timeout -= EndStun;
        this.ProcessMode = ProcessModeEnum
                        .          Inherit ;
    }
}




















