using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class EyeSight3D : Node3D
{
    [Export] public float MinRotationY { get; set; } = -90;
    [Export] public float MaxRotationY { get; set; } = +90;

    private Vector2 _currPosition;

    public virtual void FollowPosition(Vector2 @position)
    {
        _currPosition =
        _currPosition.Lerp(@position, 0.1f);

        float rotationY = Mathf.Clamp(_currPosition.Angle()
                        , Mathf.DegToRad(MinRotationY)
                        , Mathf.DegToRad(MaxRotationY))
                        - Mathf.DegToRad(45);

              Rotation  =
              Rotation
    with{ Y =-rotationY , };
    }

    [Export]
    public double               RotateDuration { get; set; } // = ~ Rotate Speed In Seconds
    [Export]
    public Tween.      EaseType EasingfuncType { get; set; } // For Rotate Smoothly
    [Export]
    public Tween.TransitionType TransitionType { get; set; } // For Rotate Smoothly

    public virtual void FollowRotationDegreesY(float
                             @rotationDegreesY)
    {
        Tween tween =
        GetParent  ().
        CreateTween();
        tween.TweenProperty(this              ,
        "rotation_degrees:y",@rotationDegreesY,
                       RotateDuration);
        tween.SetEase (EasingfuncType)
             .SetTrans(TransitionType);
    }

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode = ProcessModeEnum.Disabled;        
    }
}





