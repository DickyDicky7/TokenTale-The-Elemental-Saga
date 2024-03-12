using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Shared;

[GlobalClass]
public abstract partial class BaseFlippableComponent : Node
{
public abstract Transform2D Flip(Transform2D @transform2D, Vector2 @direction);
}
