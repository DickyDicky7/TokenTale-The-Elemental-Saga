using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class CustomArea3D : Area3D
{
    public virtual void StartWatching()
    {
        AreaEntered += OnAreaEntered;
        BodyEntered += OnBodyEntered;
    }

    public virtual void StopWatching()
    {
        AreaEntered -= OnAreaEntered;
        BodyEntered -= OnBodyEntered;
    }

    protected abstract void OnAreaEntered(Area3D @area3D);
    protected abstract void OnBodyEntered(Node3D @node3D);
}
