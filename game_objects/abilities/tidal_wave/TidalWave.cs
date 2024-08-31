using     Godot                    ;

namespace TokenTaleTheElementalSaga;

public partial class TidalWave : Ability3D
{
    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        LookAt(target: @movingDirection, up: Vector3.Up, useModelFront: false);

    }
}
