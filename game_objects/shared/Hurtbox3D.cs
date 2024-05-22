using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class Hurtbox3D : CustomArea3D
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

    protected override void OnAreaEntered(Area3D @area3D)
    {
        //float oldHealth =   Character3D.CurrentHealth;
        //float newHealth = --Character3D.CurrentHealth;
        //Character3D.EmitSignal(
        //Character3D.SignalName.HealthChange,
        //Character3D,
        //oldHealth  ,
        //newHealth );
        Hurt = true;
    }

    protected override void OnBodyEntered(Node3D @node3D)
    {
        //throw new System.NotImplementedException();
    }
}
















