using Godot;

namespace TokenTaleTheElementalSaga;

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

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode = ProcessModeEnum.Disabled;
    }
}
