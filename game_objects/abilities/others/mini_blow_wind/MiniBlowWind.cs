using Godot;

namespace TokenTaleTheElementalSaga;

public partial class MiniBlowWind : Ability3D
{
    [Export]
    public GpuParticles3D
           GpuParticles
    {
        get;
        set;
    }

    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        if (@movingDirection.X < 0)
        {
            GpuParticles.
                    ProcessMaterial =
            GpuParticles.
                    ProcessMaterial.Duplicate(subresources: false) as Material;
            if (GpuParticles.
                        ProcessMaterial
            is  ParticleProcessMaterial
                particleProcessMaterial)
            {
                particleProcessMaterial.Gravity = new(-0.1f, 0.0f, 0.0f);
            }
            GpuParticles.DrawPass1 =
            GpuParticles.DrawPass1 .Duplicate(subresources:!false)
            as Mesh;
            if (
            GpuParticles.DrawPass1.
SurfaceGetMaterial(surfIdx: 0)
            is  StandardMaterial3D
                standardMaterial3D)
            {
                standardMaterial3D.
                Uv1Scale                        = new(-1.0f, 1.0f, 1.0f);
            }
        }
    }
    public override void _Ready()
    {
        base._Ready();
        this.ActiveRange = AbilityStats.ActiveRange.Long;
        this.Speed = AbilityStats.Speed.MidFast;
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
