using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class Hittbox3D : CustomArea3D
{
    public bool Hit { get; set; } = false;
    protected override void OnAreaEntered(Area3D @area3D)
    {
		this.Hit = true;
    }
    protected virtual void Action()
    {

    }

    protected override void OnBodyEntered(Node3D @node3D)
    {
        throw new System.NotImplementedException();
    }
}


