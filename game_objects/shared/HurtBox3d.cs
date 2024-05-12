using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HurtBox3d : Area3D
{
    public Character3D
           Character3D
    {
        get;
        set;
    }

    public bool
           Hurt
    {
        get;
        set;
    } = false;

    protected void OnAreaEntered(Area3D @area3D)
    {
        int oldHealth =   Character3D.Health;
        int newHealth = --Character3D.Health;
        Character3D.EmitSignal(
        Character3D.SignalName.HealthChange,
        Character3D,
        oldHealth  ,
        newHealth );
        Hurt = true;
    }

    public void StartWatching()
    {
        this.AreaEntered += OnAreaEntered;
    }

    public void StopWatching()
    {
        this.AreaEntered -= OnAreaEntered;
    }
}
