using Godot;

namespace TokenTaleTheElementalSaga;

public partial class MiniPenetratingSquirt : Ability3D
{
    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        LookAt(target: @movingDirection, up: Vector3.Up, useModelFront: false);
    }
    public override void _Ready()
    {
        base._Ready();
        this.DamageRatio = 1.0f;
    }
    public override Vector3 CalculateCeasePosition(
        Vector3 @movingDirection,
        Vector3 @startPosition,
        Vector3 @ceasePosition)
    {
        return @startPosition;
    }
}
