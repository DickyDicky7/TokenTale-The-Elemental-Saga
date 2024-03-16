using Godot;

namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Bow_ : Weapon
#pragma warning restore IDE1006 // Naming Styles
{
    [Export] public AnimatedSprite2D AnimatedSprite2D__Main { get; set; }
    [Export] public CollisionShape2D CollisionShape2D       { get; set; }
    [Export] public AnimatedSprite2D AnimatedSprite2DEffect { get; set; }

    public Vector2 CurrentRotationPosition { get; set; }
}
