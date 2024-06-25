using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Arrow : Weapon
{
    public Vector3 StartPosition { get; set; }
    public Vector3 CeasePosition { get; set; }
    public double MovingDuration { get; set; }
    public double MovingDelaying { get; set; }
    public Tween.      EaseType EasingfuncType { get; set; } = Tween.      EaseType.InOut;
    public Tween.TransitionType TransitionType { get; set; } = Tween.TransitionType.Quint;
    public _Bow_ Bow { get; set; }

    [Export]
    public Area3D
           Hitbox
    {
        get;
        set;
    }

    [Export]
    public GpuParticles3D
           GpuParticles3D
    {
        get;
        set;
    }

    [Export]
    public AudioStreamPlayer
           AudioStreamPlayer
    {
        get;
        set;
    }

    [Export]
    public AudioStream
           AudioStream
    {
        get;
        set;
    }

    public          void _Setup(Node @node)
    {
        node.GetTree ()
            .   Root
            .AddChild(
                this  ,
    forceReadableName:  false      ,
            @internal:  InternalMode
            .Disabled);
    }

    public override void _Ready()
    {
                    base._Ready();

        LookAt(target: CeasePosition
                     - StartPosition, up: Vector3.Up, useModelFront: false);
                 Hitbox.BodyEntered +=
                 Hitbox_BodyEntered ;
             Move();
    }

    private Tween
            tween  ;

    private void Hitbox_BodyEntered(Node3D @body)
    {
        AudioStreamPlayer.Stream = AudioStream;
        AudioStreamPlayer.Play();
             Stop();
        if (body is Monster monster)
        {
            float damage = this.Bow.OwnerMainCharacter.CalculatePhysicsDamage(monster);
            monster.CurrentHealth -= damage;
            monster.EmitSignal(Character3D.SignalName.HealthChange, damage);
        }
//      QueueFree();
    }
    public Vector3 CalculateCeasePosition(
        Vector3 startPosition,
        Vector3 ceasePosition)
    {
        float maxRange = AbilityStats.ActiveRange.Long;
        Vector3 movingDirection = startPosition.DirectionTo(ceasePosition).Normalized();
        Vector3 newCeasePosition = startPosition + movingDirection * maxRange;
        newCeasePosition = new Vector3(newCeasePosition.X, startPosition.Y, newCeasePosition.Z);
        return newCeasePosition;
    }
    public double CalculateMovingDuration(float distance)
    {
        return this.MovingDuration = distance / AbilityStats.Speed.Quick;
    }

    private void Move()
    {
        Position     =     StartPosition;
//      Tween
        tween =   CreateTween();
        tween .         TweenProperty (
        this, "position" , CeasePosition,
                        MovingDuration)
              .SetDelay(MovingDelaying);
        tween .SetEase (EasingfuncType)
              .SetTrans(TransitionType);
        tween .         TweenCallback (Callable.From(() =>
        {
             Stop();
//      QueueFree();
        }));
    }

    private void Stop()
    {
        GpuParticles3D.Emitting = false;
        tween         .
        Clear    ();
        tween =   CreateTween();
        tween .         TweenCallback (Callable.From(QueueFree))
              .              SetDelay (          0.5d          );
    }
}











