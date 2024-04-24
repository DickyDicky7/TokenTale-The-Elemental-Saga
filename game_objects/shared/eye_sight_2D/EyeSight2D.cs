using Godot;

namespace TokenTaleTheElementalSaga;

public partial class EyeSight2D : PointLight2D
{
    [Export] public float MinRotation { get; set; } = -90;
    [Export] public float MaxRotation { get; set; } = +90;

    private Vector2 _currPosition;

    public virtual void FollowPosition(Vector2 @position)
    {
        _currPosition =
        _currPosition.Lerp(@position, 0.1f);

        //Rotation = Mathf.Clamp(_currPosition.Angle()
        //    , -1 * Mathf.Pi / 2
        //    , +1 * Mathf.Pi / 2)
        //         - Mathf.Pi / 4;

        Rotation = Mathf.Clamp(_currPosition.Angle()
                 , Mathf.DegToRad(MinRotation)
                 , Mathf.DegToRad(MaxRotation))
                 - Mathf.DegToRad(45);
    }

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode = ProcessModeEnum.Disabled;
    }
}
