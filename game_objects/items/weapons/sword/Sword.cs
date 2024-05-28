using Godot;
using Aareaa3D         = Godot.
                                        Area3D;
using AnimationPlayerr = Godot.AnimationPlayer;

namespace TokenTaleTheElementalSaga;

public partial class Sword : Weapon
{
    [Export] public Sprite3D Sprite3D { get; set; }
    [Export] public Sprite3D Shadow3D { get; set; }
    [Export] public Aareaa3D Aareaa3D { get; set; }
    [Export] public CollisionShape3D CollisionShape3D { get; set; }

    [Export] public AnimatedSprite3D AnimatedSprite3D { get; set; }
    [Export] public AnimatedSprite3D AnimatedShadow3D { get; set; }

    [Export] public AnimationPlayerr AnimationPlayerr { get; set; }

    public int SlashCount { get; set; }
    public     Vector2
    DefaultOffsetSprite3D
    { get; private set; }

    public override void _Ready()
    {
                    base._Ready();

        DefaultOffsetSprite3D = Sprite3D.Offset;
    }
}
