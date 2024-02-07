using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Shared;

public partial class HFlippable : Node
{
    private bool _isHFlipped = false;

    public Transform2D Flip(Transform2D _transform2D_, Vector2 _direction_)
    {
        if ((_direction_.X < 0 && !_isHFlipped)
        ||  (_direction_.X > 0 &&  _isHFlipped))
        {
            _transform2D_.X *= -1;
            _isHFlipped = !_isHFlipped;
        }

        if (_transform2D_.X.X.ToString() == "-0") _transform2D_.X.X = 0;
        if (_transform2D_.X.Y.ToString() == "-0") _transform2D_.X.Y = 0;
        if (_transform2D_.Y.X.ToString() == "-0") _transform2D_.Y.X = 0;
        if (_transform2D_.Y.Y.ToString() == "-0") _transform2D_.Y.Y = 0;

        return _transform2D_;
    }
}

