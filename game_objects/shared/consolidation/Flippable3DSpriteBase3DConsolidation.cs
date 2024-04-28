using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool       ]
[GlobalClass]
public sealed partial class Flippable3DSpriteBase3DConsolidation : Node
{
    [Export]
    public Array<SpriteBase3D> Sprites { get; set; }

    [Export]
    public bool FlipH
    {
        get => Sprites[0].FlipH;
        set
        {
            foreach        (
               SpriteBase3D
               sprite
            in Sprites     )
            {
               sprite    .FlipH = value;
            }
        }
    }

    [Export]
    public bool FlipV
    {
        get => Sprites[0].FlipV;
        set
        {
            foreach        (
               SpriteBase3D
               sprite
            in Sprites     )
            { 
               sprite    .FlipV = value;
            }
        }
    }

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode     =
        ProcessModeEnum .Disabled;
    }
}
