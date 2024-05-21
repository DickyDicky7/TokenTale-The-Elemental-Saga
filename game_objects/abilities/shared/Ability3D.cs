using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Ability3D : Node3D
{
    public      Node3D Spacex { get; set; }
    public Character3D Caster { get; set; }
    [Export]
    public double               MovingDelaying { get; set; }
    [Export]
    public double               MovingDuration { get; set; } // = ~ Moving Speed In Seconds
    [Export]
    public Tween.      EaseType EasingfuncType { get; set; } // For Moving Smoothly
    [Export]
    public Tween.TransitionType TransitionType { get; set; } // For Moving Smoothly
    public float ActiveRange { get; protected set; } = AbilityStats.ActiveRange.Short;
    public float Speed { get; protected set; } = AbilityStats.Speed.Slow;
    public float DamageRatio { get; set; } = 1.0f;
    [Export]
    public Global.Element Element { get; protected set; }

    public virtual Vector3 CalculateCeasePosition(
        Vector3 MovingDirection,
        Vector3 StartPosition,
        Vector3 CeasePosition)
    {
        if (StartPosition.DistanceTo(CeasePosition) > this.ActiveRange)
            return StartPosition + MovingDirection * this.ActiveRange;
        else
            return CeasePosition;
    }
    public virtual double CalculateMovingDuration(float distance)
    {
        return this.MovingDuration == 0 ? 0 : distance / Speed;
    }

    public Tween 
           tween;

    public virtual Vector3 CalculateMovingDirection(
                   Vector3 @startPosition          ,
                   Vector3 @ceasePosition          )
    {
        return   (         @ceasePosition
             -             @startPosition)
             .             Normalized   ();
    }

    public virtual void ChangeVisual(Vector3 @movingDirection)
    {
    }

    public virtual void Stop             (
                                         )
    {
        tween .Clear();
    }

    public virtual void Move             (
                   Vector3 @startPosition,
                   Vector3 @ceasePosition)
    {
        Position     =     @startPosition;
//      Tween
        tween =   CreateTween();
        tween .         TweenProperty (
        this, "position" , @ceasePosition,
                        MovingDuration)
              .SetDelay(MovingDelaying);
        tween .SetEase (EasingfuncType)
              .SetTrans(TransitionType);
    }


    // PATTERN: TEMPLATE METHOD
    public virtual void Attach(
             Node3D @spacex   ,
        Character3D @caster   ,
        Vector3 @startPosition,
        Vector3 @ceasePosition)
    {
         Caster=
        @caster;
         Spacex=
        @spacex;
        @spacex.AddChild(this, forceReadableName: false, @internal: InternalMode.Disabled);
        Vector3
        movingDirection = CalculateMovingDirection(
                @startPosition                    ,
                @ceasePosition                    );
        ChangeVisual   (
        movingDirection);
        Vector3 newCeasePosition = CalculateCeasePosition(movingDirection, @startPosition, @ceasePosition);
        this.MovingDuration = CalculateMovingDuration(startPosition.DistanceTo(newCeasePosition));
        Move                                      (
                @startPosition                    ,
                newCeasePosition                   );
    }
}












