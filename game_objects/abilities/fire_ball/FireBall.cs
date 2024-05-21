using Godot;

namespace TokenTaleTheElementalSaga;

public partial class FireBall : Ability3D
{
    [Export]
    public GpuParticles3D
           GpuParticles
    {
        get;
        set;
    }

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

            GpuParticles.
                       ProcessMaterial =
            GpuParticles.
                       ProcessMaterial.Duplicate(subresources: false) as Material;
        if (GpuParticles.
                       ProcessMaterial
        is     ParticleProcessMaterial
               particleProcessMaterial)
        {
               particleProcessMaterial.Gravity   = -@movingDirection;
               particleProcessMaterial.Direction = -@movingDirection;
        }

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
	public override void _Ready()
	{
		base._Ready();
        this.ActiveRange = AbilityStats.ActiveRange.Long;
        this.Speed = AbilityStats.Speed.MidFast;
        this.DamageRatio = 1.0f;
	}
	public override Vector3 CalculateCeasePosition(
        Vector3 @movingDirection                  , 
        Vector3 @startPosition                    ,
        Vector3 @ceasePosition                    )
	{
		return  @startPosition +
                @movingDirection 
      * this.ActiveRange ;
	}
}
