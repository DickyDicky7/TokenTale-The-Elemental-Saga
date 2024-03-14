using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HFlippable2DLocalLookingDirectionComponent : HFlippable2DComponent
{
    [Export]
    public Node2D
           Node2D
    {
        get;
        set;
    }

    [Export]
    public Vector2
           LocalLookingDirection
    {
        get;
        set;
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);
        Node2D.Transform = Flip2D(Node2D.Transform, LocalLookingDirection);
    }
}
