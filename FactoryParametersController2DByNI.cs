using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class FactoryParametersController2DByNI : FactoryParametersController2D
{
    public override Vector2 MovingDirection2D
        => Input.GetVector("L", "R", "U", "D");
}
