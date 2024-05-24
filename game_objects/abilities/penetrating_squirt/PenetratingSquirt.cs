using Godot;

namespace TokenTaleTheElementalSaga;

public partial class PenetratingSquirt : Ability3D
{
	[Export]
	GpuParticles3D GPUParticles3D { get; set; }
	[Export]
	AnimationPlayer AnimationPlayer { get; set; }
	[Export]
	CollisionShape3D CollisionShape3D { get; set; }
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
		this.DamageRatio = 1.2f;
		this.GPUParticles3D.Lifetime *= ScaleAbility;
		this.GPUParticles3D.SpeedScale = this.GPUParticles3D.SpeedScale *= ScaleAbility;
		this.AnimationPlayer.GetAnimation("SHOOT").Length += (float)this.GPUParticles3D.Lifetime;
		if (this.CollisionShape3D.Shape is SeparationRayShape3D separationRayShape3D)
		{
			separationRayShape3D.Length *= ScaleAbility;
		}
	}
	public override void _ExitTree()
	{
		base._ExitTree();
		this.AnimationPlayer.GetAnimation("SHOOT").Length -= (float)this.GPUParticles3D.Lifetime;
		this.GPUParticles3D.Lifetime /= ScaleAbility;
		this.GPUParticles3D.SpeedScale = this.GPUParticles3D.SpeedScale /= ScaleAbility;
		if (this.CollisionShape3D.Shape is SeparationRayShape3D separationRayShape3D)
		{
			separationRayShape3D.Length /= ScaleAbility;
		}
	}
	public override Vector3 CalculateCeasePosition(
		Vector3 @movingDirection,
		Vector3 @startPosition,
		Vector3 @ceasePosition)
	{
		return @startPosition;
	}
}
