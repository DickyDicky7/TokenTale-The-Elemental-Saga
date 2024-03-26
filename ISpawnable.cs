using Godot;

namespace TokenTaleTheElementalSaga;

public enum 
    SpawnableStatus
{
    SUCCESS,
    FAILURE,
}

public interface ISpawnable
{
    SpawnableStatus Spawn(Marker2D @spawnerPivot, Vector2 @spawnGlobalPosition);
}
