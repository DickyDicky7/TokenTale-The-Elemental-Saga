using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HFlippable2DInputDirectionComponent : HFlippable2DComponent
{
    [Export]
    public Node2D Node2D { get; set; }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);
        Vector2 inputDirection = Extension
            .GetInputDirection();
        Node2D
            .Transform = Flip2D(Node2D.Transform, inputDirection);
    }
}
