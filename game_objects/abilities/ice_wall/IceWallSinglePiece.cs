using Godot;

namespace     TokenTaleTheElementalSaga ;

public partial class IceWallSinglePiece : StaticBody3D
{
    [Export]
    public MeshInstance3D Mesh { get; set; }

    public override void _Ready()
    {
                    base._Ready();
        Scale =
        Scale with {  Y = 0.001f  };
        Tween tween = CreateTween();
        tween.SetLoops(1)
             .TweenProperty(this, "scale:y", 1, 0.3d)
             .SetEase (Tween.      EaseType.Out  )
             .SetTrans(Tween.TransitionType.Quart)
             .SetDelay(GD.RandRange(0.0d, 1.0d));
    }
}
