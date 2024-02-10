using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Shared;

public partial class EyeSight : PointLight2D
{
    [Export]
    public float MinRotation { get; set; } = -90;
    [Export]
    public float MaxRotation { get; set; } = +90;

    public virtual void FollowPosition(Vector2 _position_)
    {
        //Rotation = Mathf.Clamp(_position_.Angle()
        //    , -1 * Mathf.Pi / 2
        //    , +1 * Mathf.Pi / 2)
        //         - Mathf.Pi / 4;

        Rotation = Mathf.Clamp(_position_.Angle()
                 , Mathf.DegToRad(MinRotation)
                 , Mathf.DegToRad(MaxRotation))
                 - Mathf.DegToRad(45);
    }
}
