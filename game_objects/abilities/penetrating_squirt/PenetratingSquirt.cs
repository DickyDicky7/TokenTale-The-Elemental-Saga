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
	public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        LookAt(target: @movingDirection, up: Vector3.Up, useModelFront: false);
    }
	public override void _Ready()
	{
		base._Ready();
		this.DamageRatio = 1.2f;
	}
	public override Vector3 CalculateCeasePosition(
		Vector3 @movingDirection,
		Vector3 @startPosition,
		Vector3 @ceasePosition)
	{
		return @startPosition;
	}
}
