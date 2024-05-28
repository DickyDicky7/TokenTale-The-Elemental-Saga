using Godot;

namespace TokenTaleTheElementalSaga;

public partial class MiniThunderShock : Ability3D
{
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

        if (                                  @movingDirection.X <= 0.0f)
        {
            Flippable3DSpriteBase3DConsolidation.FlipH = !false;
        }
        else
        {
            Flippable3DSpriteBase3DConsolidation.FlipH =  false;
        }
    }
	public override void _Ready()
	{
		base._Ready();
        this.ActiveRange = AbilityStats.ActiveRange.Medium;
        this.DamageRatio = 1.0f;
	}
}
