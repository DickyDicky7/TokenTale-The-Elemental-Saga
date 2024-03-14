using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HFlippable2DComponent : Flippable2DComponent
{
    private bool _isHFlipped2D = false;

    public override Transform2D Flip2D(Transform2D @transform2D, Vector2 @direction)
    {
        if ((@direction.X < 0.0f && !_isHFlipped2D)
        ||  (@direction.X > 0.0f &&  _isHFlipped2D))
        {
             @transform2D.X *= -1.0f;
            _isHFlipped2D = !_isHFlipped2D;
        }

        if (@transform2D.X.X.ToString() == "-0") @transform2D.X.X = 0.0f;
        if (@transform2D.X.Y.ToString() == "-0") @transform2D.X.Y = 0.0f;
        if (@transform2D.Y.X.ToString() == "-0") @transform2D.Y.X = 0.0f;
        if (@transform2D.Y.Y.ToString() == "-0") @transform2D.Y.Y = 0.0f;

        return @transform2D;
    }
}

