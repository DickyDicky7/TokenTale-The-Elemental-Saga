using Godot;

namespace TokenTaleTheElementalSaga.GameObjects;

public partial class HFlippable
{
    private bool _isFlipped = false;

    public Transform2D Flip(Transform2D _transform2D_, Vector2 _direction_)
    {
        if ((_direction_.X == -1 && !_isFlipped)
        ||  (_direction_.X == +1 &&  _isFlipped))
        {
            _transform2D_.X *= -1;
            _isFlipped = !_isFlipped;
        }

        if (_transform2D_.X.X.ToString() == "-0") _transform2D_.X.X = 0;
        if (_transform2D_.X.Y.ToString() == "-0") _transform2D_.X.Y = 0;
        if (_transform2D_.Y.X.ToString() == "-0") _transform2D_.Y.X = 0;
        if (_transform2D_.Y.Y.ToString() == "-0") _transform2D_.Y.Y = 0;

        return _transform2D_;
    }
}

