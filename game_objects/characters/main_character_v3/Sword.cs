using Godot;
using AnimationPlayer_ = Godot.AnimationPlayer;

namespace TokenTaleTheElementalSaga;

public partial class Sword : Weapon2D
{
    [Export] public Sprite2D Sprite2D { get; set; }
    [Export] public CollisionShape2D CollisionShape2D { get; set; }

    [Export] public AnimatedSprite2D AnimatedSprite2D { get; set; }

    [Export] public AnimationPlayer_ AnimationPlayer_ { get; set; }

    public int SlashCount { get; set; }
    public     Vector2
    DefaultOffsetSprite2D
    { get; private set; }

    public override void _Ready()
    {
        base._Ready();
        DefaultOffsetSprite2D = Sprite2D.Offset;
    }
}
