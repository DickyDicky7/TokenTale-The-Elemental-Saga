using Godot;

namespace TokenTaleTheElementalSaga;

//[Tool]
public partial class MiniFireBall : Ability3D
{
    //[Export]
    //public GpuParticles3D
    //       GpuParticles
    //{
    //    get;
    //    set;
    //}

    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        //    GpuParticles.
        //            ProcessMaterial =
        //    GpuParticles.
        //            ProcessMaterial.Duplicate(subresources: false) as Material;
        //if (GpuParticles.
        //            ProcessMaterial
        //is  ParticleProcessMaterial
        //    particleProcessMaterial)
        //{
        //    particleProcessMaterial.Gravity   = -@movingDirection;
        //    particleProcessMaterial.Direction = -@movingDirection;
        //}

        LookAt(target: @movingDirection, up: Vector3.Up, useModelFront: false);
    }
    public override void _Ready()
    {
        base._Ready();
        this.ActiveRange = AbilityStats.ActiveRange.Long;
        this.Speed = AbilityStats.Speed.Quick;
        this.DamageRatio = 1.0f;
    }
    public override Vector3 CalculateCeasePosition(
        Vector3 @movingDirection,
        Vector3 @startPosition,
        Vector3 @ceasePosition)
    {
        return @startPosition + @movingDirection * this.ActiveRange;
    }
}
