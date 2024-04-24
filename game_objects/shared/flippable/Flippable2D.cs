using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Flippable2D : Node
{
public abstract Transform2D Flip2D(Transform2D @transform2D, Vector2 @direction);
}
