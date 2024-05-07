using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Ability3D : Node3D
{
    public      Node3D Spacex { get; set; }
    public Character3D Caster { get; set; }
    [Export]
    public double               MovingDuration { get; set; } // = ~ Moving Speed
    [Export]
    public Tween.      EaseType EasingfuncType { get; set; } // For Moving Smoothly
    [Export]
    public Tween.TransitionType TransitionType { get; set; } // For Moving Smoothly

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

    public virtual void Move             (
                   Vector3 @startPosition,
                   Vector3 @ceasePosition)
    {
        Position     =     @startPosition;
        Tween
        tween =   CreateTween();
        tween .         TweenProperty (
        this, "position" , @ceasePosition,
                        MovingDuration);
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
        Move                                      (
                @startPosition                    ,
                @ceasePosition                    );
    }
}












