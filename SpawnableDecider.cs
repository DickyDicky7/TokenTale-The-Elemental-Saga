using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class SpawnableDecider : Resource
{
    [Export]
    public  bool UseRange { get; set; }
    [Export]
    public float MinRange { get; set; }
    [Export]
    public float MaxRange { get; set; }

    public bool IsGlobalPositionSpawnable(Marker2D @spawnerPivot, Vector2 @spawnGlobalPosition)
    {
        if (UseRange)
        {
            Vector2 spawnLocalPosition
                 = @spawnerPivot.ToLocal(
                   @spawnGlobalPosition );
            Vector2 spawnDirection
                 =
            Vector2.Right.Rotated           (
                    spawnLocalPosition.Angle());
            return 
                    spawnLocalPosition.Clamp(
                    spawnDirection * MinRange  ,
                    spawnDirection * MaxRange) == spawnLocalPosition;
        }
        else
        {
            return true;
        }
    }
}
