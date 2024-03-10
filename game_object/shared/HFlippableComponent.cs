using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Shared;

[GlobalClass]
public partial class HFlippableComponent : BaseFlippableComponent
{
    private bool _isHFlipped = false;

    public override Transform2D Flip(Transform2D @transform2D, Vector2 @direction)
    {
        if ((@direction.X < 0 && !_isHFlipped)
        ||  (@direction.X > 0 &&  _isHFlipped))
        {
            @transform2D.X *= -1;
            _isHFlipped = !_isHFlipped;
        }

        if (@transform2D.X.X.ToString() == "-0") @transform2D.X.X = 0;
        if (@transform2D.X.Y.ToString() == "-0") @transform2D.X.Y = 0;
        if (@transform2D.Y.X.ToString() == "-0") @transform2D.Y.X = 0;
        if (@transform2D.Y.Y.ToString() == "-0") @transform2D.Y.Y = 0;

        return @transform2D;
    }
}

