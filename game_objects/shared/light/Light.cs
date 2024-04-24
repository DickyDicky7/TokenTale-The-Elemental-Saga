using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Light : PointLight2D
{
    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        this.GlobalPosition = GetGlobalMousePosition();
    }
}
