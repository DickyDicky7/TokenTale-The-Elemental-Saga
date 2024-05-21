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

    [Export]
    public Area3D Hitbox { get; set; }

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
             Stop();
        QueueFree();
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
        QueueFree();
        }));
    }

    private void Stop()
    {
        tween  .
        Clear();
    }
}








