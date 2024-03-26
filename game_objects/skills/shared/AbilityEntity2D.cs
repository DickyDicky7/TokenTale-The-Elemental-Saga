using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class AbilityEntity2D : Area2D, ISpawnable
{
    [Export]
    public RadiusRange RadiusRange { get; set; }
    [Export]
    public MovingSpeed MovingSpeed { get; set; }
    [Export]
    public HitboxShape HitboxShape { get; set; }
    
    public SpawnableStatus Spawn(Marker2D spawnerPivot, Vector2 spawnGlobalPosition)
    {
        Vector2 spawnLocalPosition
     = @spawnerPivot.ToLocal(
       @spawnGlobalPosition);
        Vector2 spawnDirection
             =
        Vector2.Right.Rotated(
                spawnLocalPosition.Angle());
        if (
                spawnLocalPosition.Clamp(
                spawnDirection * RadiusRange.Min,
                spawnDirection * RadiusRange.Max) == spawnLocalPosition)
        {
            GlobalPosition = spawnGlobalPosition;
            spawnerPivot.GetTree().Root.AddChild(this);
            return SpawnableStatus.SUCCESS;
        }
        return SpawnableStatus.FAILURE;

    }
}
