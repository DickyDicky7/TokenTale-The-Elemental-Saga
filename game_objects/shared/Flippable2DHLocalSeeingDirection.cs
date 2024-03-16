using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class Flippable2DHLocalSeeingDirection : Flippable2DH
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
           LocalSeeingDirection
    {
        get;
        set;
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        Node2D.Transform = Flip2D(Node2D.Transform, LocalSeeingDirection);
    }
}
