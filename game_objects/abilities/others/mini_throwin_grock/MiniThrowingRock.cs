using Godot;

namespace TokenTaleTheElementalSaga;

public partial class MiniThrowingRock : Ability3D
{
    [Export]
    public Curve
           Curve
    {
        get;
        set;
    }

    [Export]
    public Sprite3D Sprite { get; set; }
    [Export]
    public Sprite3D Shadow { get; set; }
    [Export]
    public Flippable3DSpriteBase3DConsolidation
           Flippable3DSpriteBase3DConsolidation
    {
        get;
        set;
    }

    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        float rotationDegreesZ;
        if (                                  @movingDirection.X <= 0.0f)
        {
              rotationDegreesZ = +30.0f;
            Flippable3DSpriteBase3DConsolidation.FlipH = !false;
        }
        else
        {
              rotationDegreesZ = -30.0f;
            Flippable3DSpriteBase3DConsolidation.FlipH =  false;
        }
        int offsetX = GD.RandRange(0, 2);
        int offsetY = GD.RandRange(0, 1);
        int w = 24;
        int h = 24;
        int x = offsetX * w;
        int y = offsetY * h;
        Shadow.RegionRect =
        Sprite.RegionRect =
        Sprite.RegionRect with
        {
            Position = new(x, y),
            Size     = new(w, h),
        };
        Tween tween = CreateTween();
        tween.TweenProperty(Sprite, "rotation_degrees:z", rotationDegreesZ, MovingDuration / 2.0f);
        tween.SetEase (EasingfuncType)
             .SetTrans(TransitionType);
        tween.TweenProperty(Sprite, "rotation_degrees:z", 0000000000000000, MovingDuration / 2.0f);
        tween.SetEase (EasingfuncType)
             .SetTrans(TransitionType);
    }

    public override void Move(Vector3 @startPosition, Vector3 @ceasePosition)
    {
                    base.Move(        @startPosition,         @ceasePosition);
        float offSetY = startPosition.Y;
        Tween tween = CreateTween();
        tween.TweenMethod(Callable.From((float @time) =>
        {
            Position=
            Position with
            {
                Y   =  Curve
                    . Sample(@time / (float)MovingDuration) + offSetY,
            };
        })   , 0.0f ,  MovingDuration ,
                       MovingDuration);
        tween.SetEase (EasingfuncType)
             .SetTrans(TransitionType);
    }
	public override void _Ready()
	{
		base._Ready();
		this.ActiveRange = AbilityStats.ActiveRange.Great;
		this.Speed = AbilityStats.Speed.Fast;
        this.DamageRatio = 1.0f;
	}
}







