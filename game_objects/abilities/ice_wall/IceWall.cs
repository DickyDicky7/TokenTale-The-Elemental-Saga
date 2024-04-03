using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

public partial class IceWall : Area2D
{
    [Export]
    public Array<GpuParticles2D> GpuParticles { get; set; }
    [Export]
    public Array<        Sprite2D>         Sprites { get; set; }
    [Export]
    public Array<AnimatedSprite2D> AnimatedSprites { get; set; }
    [Export]
    public       CollisionShape2D  CollisionShape  { get; set; }
    [Export]
    public float  Space  { get; set; }
    [Export]
    public Node2D Caster { get; set; }

    public override void _Ready()
    {
                    base._Ready();

        float _ = -Sprites.Count / 2.0f;
        for (int
          index = 0;
          index <  Sprites.Count       ;
        ++index)
        {
            Sprites[index].Position =
            Sprites[index].Position with { X = _++ * Space };
            AnimatedSprites[index].Position = Sprites[index].Position;
               GpuParticles[index].Position = Sprites[index].Position;
        }
    }

    Vector2 f;
    Vector2 t;
    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        this.GlobalPosition = GetGlobalMousePosition();

        f = Caster.GetLocalMousePosition();

        float r = Mathf.Pi / 2;
        if (f.Angle() >= -r && f.Angle() < r)
            r = +r;
        else
            r = -r;

        t = Caster.GetLocalMousePosition().Rotated(r).Normalized();

        int _   = -Sprites.Count / 2;
        for (int
          index = 0;
          index <  Sprites.Count    ;
        ++index)
        {
            Sprites[index].Position =
            Sprites[index].Position with { X = _ * Space * t.X, Y = _ * Space * t.Y };
            _++;
            AnimatedSprites[index].Position = Sprites[index].Position;
               GpuParticles[index].Position = Sprites[index].Position;
        }
        CollisionShape.Rotation = Sprites[0].Position.Angle();
    }

    
}
