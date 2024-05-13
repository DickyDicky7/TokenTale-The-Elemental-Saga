using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class CustomArea3D : Area3D
{
    public virtual void StartWatching()
    {
        AreaEntered += OnAreaEntered;
    }

    public virtual void StopWatching()
    {
        AreaEntered -= OnAreaEntered;
    }

    protected abstract void OnAreaEntered(Area3D @area3D);
}
