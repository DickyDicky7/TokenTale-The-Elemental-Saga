using Godot;

namespace     TokenTaleTheElementalSaga ;

public partial class IceWallSinglePiece : StaticBody3D
{
    [Export]
    public MeshInstance3D Mesh { get; set; }

    public override void _Ready()
    {
                    base._Ready();
    }

    public void _Show()
    {
        Scale =
        Scale with {  Y = 0.001f  };
        Tween tween = CreateTween();
        tween.SetLoops(1)
             .TweenProperty(this, "scale:y", 1.000f, 0.3d)
             .SetEase (Tween.      EaseType.Out  )
             .SetTrans(Tween.TransitionType.Quart)
             .SetDelay(GD.RandRange(0.0d, 1.0d));
    }

    public void _Hide()
    {
        Scale =
        Scale with {  Y = 1.000f  };
        Tween tween = CreateTween();
        tween.SetLoops(1)
             .TweenProperty(this, "scale:y", 0.001f, 0.3d)
             .SetEase (Tween.      EaseType.Out  )
             .SetTrans(Tween.TransitionType.Quart)
             .SetDelay(GD.RandRange(0.0d, 1.0d));
        tween.SetLoops(1)
             .TweenProperty(this,
        "position:y",
         Position.Y - 1.0f, 0.3d)
             .SetEase (Tween.      EaseType.Out  )
             .SetTrans(Tween.TransitionType.Quart);
    }
}















