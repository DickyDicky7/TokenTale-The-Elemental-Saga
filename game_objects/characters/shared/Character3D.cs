using Godot;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character3D : CharacterBody3D
{

    [Export]
    public PackedScene StatusInfoPackedScene { get; set; }
    public float CurrentHealth { get; set; }
    public float     MaxHealth { get; set; } = 1.0f;
    public float CurrentSpeed  { get; set; }
    public float     MaxSpeed  { get; set; } = 1.0f;
    public float        Jumpv  { get; set; } = 1.0f;
    public float Acceleration  { get; set; } = 0.1f;
    public float Deceleration  { get; set; } = 0.1f;
    public Global.Element ElementMark { get; set; } = Global.Element.None;
    private Timer EffectTimerSpeed { get; set; } = new();
    private Timer EffectTimerStun { get; set; } = new();
    public bool IsStunning { get; private set; } = false;
    public StatusInfo
           StatusInfo          { get; private set; }

    [Signal]
    public delegate void HealthChangeEventHandler(float damage);
    public Dictionary<string, PackedScene> AbilityPackedScenes { get; set; } = new();

    public virtual void Move(Vector3 @direction, double @delta)
    {
        if (this.IsStunning == true)
            return;
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
        this.TimerReady();
        this.StatusInfo = StatusInfoPackedScene.Instantiate<StatusInfo>();
        this.AddChild  (  StatusInfo                                    );
        base._Ready();

        //
        NavigationAgent3D
        navigationAgent3D  = GetNodeOrNull<NavigationAgent3D>
                                   (nameof(NavigationAgent3D));
    if (navigationAgent3D != null)
        navigationAgent3D.DebugEnabled = false;
        //
    }
    private void TimerReady()
    {
        this.EffectTimerSpeed.OneShot = true;
        this.EffectTimerSpeed.WaitTime = 1.0d;
        this.EffectTimerSpeed.ProcessCallback = Timer.TimerProcessCallback.Physics;
        this.EffectTimerSpeed.Timeout += EndSpeedEffect;
        this.AddChild(EffectTimerSpeed);
        this.EffectTimerStun.OneShot = true;
        this.EffectTimerStun.WaitTime = 1.0d;
        this.EffectTimerStun.ProcessCallback = Timer.TimerProcessCallback.Physics;
        this.EffectTimerStun.Timeout += EndStun;
        this.AddChild(EffectTimerStun);
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
    public abstract float CalculateElementalDamage(Ability3D ability, Character3D target);
    public abstract float CalculatePhysicsDamage(Character3D target);

    public void StartSpeedEffect(float @ratio, float @duration)
    {
        this.CurrentSpeed = this.MaxSpeed * @ratio;
        this.EffectTimerSpeed.Start(@duration);
        if (ratio < 1)
        {
            this.StatusInfo.Items.Add(
                new StatusInfoItemElemental { Element = Global.Element.None, Thing = "Speed-" });
        }
        if (ratio > 1)
        {
            this.StatusInfo.Items.Add(
                new StatusInfoItemElemental { Element = Global.Element.None, Thing = "Speed+" });
        }
    }

    public void EndSpeedEffect()
    {
        this.EffectTimerSpeed.Stop();
        this.CurrentSpeed = this.MaxSpeed;
        this.EffectTimerSpeed.WaitTime = 1.0f;
    }

    public void BePushed(Vector3 @velocity)
    {
        this.Velocity =          @velocity;
        this.MoveAndSlide();
        this.Velocity =  Vector3.Zero     ;
    }

    public void StartStun(float @duration)
    {
        this.EffectTimerStun.Start(@duration) ;
        this.IsStunning = true;
        this.StatusInfo.Items.Add(
            new StatusInfoItemElemental { Element = Global.Element.None, Thing = "Stunned" });
    }

    public void EndStun()
    {
        this.EffectTimerStun.Stop();
        this.IsStunning = false;
    }
}




















