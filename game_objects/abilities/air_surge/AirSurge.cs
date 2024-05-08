using Godot;

namespace TokenTaleTheElementalSaga;

public partial class AirSurge : Ability3D
{
    [Export]
    public AnimatedSprite3D
           AnimatedSprite
    {
        get;
        set;
    }

    [Export]
    public AnimatedSprite3D
           AnimatedShadow
    {
        get;
        set;
    }

    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        //    GpuParticles.
        //               ProcessMaterial =
        //    GpuParticles.
        //               ProcessMaterial.Duplicate(subresources: false) as Material;
        //if (GpuParticles.
        //               ProcessMaterial
        //is     ParticleProcessMaterial
        //       particleProcessMaterial)
        //{
        //       particleProcessMaterial.Gravity   = -@movingDirection;
        //       particleProcessMaterial.Direction = -@movingDirection;
        //}

        float rotation =
            @movingDirection.AngleTo(Vector3.Right);
        if (@movingDirection.Z >= 0.0f)
        {
              rotation =
            - rotation ;
        }
        AnimatedSprite.Rotation =
        AnimatedSprite.Rotation with
        { Z = rotation, };
        AnimatedShadow.Rotation =
        AnimatedShadow.Rotation with
        { Y = rotation, };
        if (@movingDirection.X <= 0.0f)
        {
            AnimatedSprite.FlipV = true;
            AnimatedShadow.FlipV = true;
        }
    }

}
