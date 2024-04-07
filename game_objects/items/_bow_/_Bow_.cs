using Godot;

namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Bow_ : Weapon
#pragma warning restore IDE1006 // Naming Styles
{
    [Export] public AnimatedSprite3D AnimatedSprite3DMmainn { get; set; }
    [Export] public CollisionShape3D CollisionShape3D       { get; set; }
    [Export] public AnimatedSprite3D AnimatedSprite3DEffect { get; set; }

    public Vector2 CurrentRotationPosition { get; set; }

    //public override void _Ready()
    //{
    //                base._Ready();

    //    AnimatedSprite3DMmainn.LookAtActiveCamera();
    //    AnimatedSprite3DEffect.LookAtActiveCamera();
    //}
}
