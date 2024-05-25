using     Godot                    ;

namespace TokenTaleTheElementalSaga;

public partial class PenetratingSquirt : Ability3D
{
	[Export]
	public GpuParticles3D
		   GPUParticles3Ddd
	{
		get;
		set;
	}

	[Export]
	public AnimationPlayer
		   AnimationPlayerr
	{
		get;
		set;
	}

	[Export]
	public CollisionShape3D
		   CollisionShape3D
	{
		get;
		set;
	}

	private float ScaleAbility { get; set; }

	public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        LookAt(target: @movingDirection, up: Vector3.Up, useModelFront: false);
    }

	public override void _Ready()
	{
					base._Ready();

		this.ScaleAbility = 1.15f;
		this. DamageRatio = 1.20f;
		this.GPUParticles3Ddd.Lifetime    *=  ScaleAbility;
		this.GPUParticles3Ddd.SpeedScale   =
		this.GPUParticles3Ddd.SpeedScale  *=  ScaleAbility;
		this.AnimationPlayerr.GetAnimation("SHOOT").Length += (float)
		this.GPUParticles3Ddd.Lifetime                    ;
		if (this.CollisionShape3D.Shape
		is   SeparationRayShape3D
		     separationRayShape3D      )
		{
			 separationRayShape3D.Length  *=  ScaleAbility;
		}
	}

	public override void _ExitTree()
	{
					base._ExitTree();

		this.AnimationPlayerr.GetAnimation("SHOOT").Length -= (float)
		this.GPUParticles3Ddd.Lifetime                    ;
		this.GPUParticles3Ddd.Lifetime    /=  ScaleAbility;
		this.GPUParticles3Ddd.SpeedScale   =
		this.GPUParticles3Ddd.SpeedScale  /=  ScaleAbility;
		if (this.CollisionShape3D.Shape
		is   SeparationRayShape3D
		     separationRayShape3D      )
		{
			 separationRayShape3D.Length  /=  ScaleAbility;
		}
	}

	public override Vector3 CalculateCeasePosition(
		Vector3 @movingDirection                  ,
		Vector3 @startPosition                    ,
		Vector3 @ceasePosition                    )
	{
		return  @startPosition                    ;
	}
}






