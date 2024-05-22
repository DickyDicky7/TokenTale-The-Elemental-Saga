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
	public override void StartWatching()
	{
		base.StartWatching();
        this.Character3D.HealthChange += this.OnHealthChange;
	}
	public override void StopWatching()
	{
		base.StopWatching();
        this.Character3D.HealthChange -= this.OnHealthChange;
	}
	protected override void OnAreaEntered(Area3D @area3D)
    {
        //Hurt = true;
    }

    protected override void OnBodyEntered(Node3D @node3D)
    {
        //Hurt = true;
    }
    private void OnHealthChange(float Damage)
    {
        if (Damage > 0)
            this.Hurt = true;
    }
	public override void _Ready()
	{
		base._Ready();
        if (this.GetParent() is Character3D)
        {
            this.Character3D = this.GetParent() as Character3D;
        }
	}
}
















