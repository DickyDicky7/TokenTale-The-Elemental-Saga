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
        get
        {
            if (FlipHInverted)
            {
                return
            !  Sprites[0].FlipH;
            }
            else
            {
                return
               Sprites[0].FlipH;
            }
        }
        set
        {
            if (FlipHInverted)
            {
                value =
            !   value ;
            }
            else
            {
#pragma warning disable CS1717 // Assignment made to same variable
                value =
                value ;
#pragma warning restore CS1717 // Assignment made to same variable
            }
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
        get
        {
            if (FlipVInverted)
            {
                return
            !  Sprites[0].FlipV;
            }
            else
            {
                return
               Sprites[0].FlipV;
            }
        }
        set
        {
            if (FlipVInverted)
            {
                value =
            !   value ;
            }
            else
            {
#pragma warning disable CS1717 // Assignment made to same variable
                value =
                value ;
#pragma warning restore CS1717 // Assignment made to same variable
            }
            foreach        (
               SpriteBase3D
               sprite
            in Sprites     )
            { 
               sprite    .FlipV = value;
            }
        }
    }

    [Export]
    public bool FlipHInverted { get; set; }
    [Export]
    public bool FlipVInverted { get; set; }

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode     =
        ProcessModeEnum .Disabled;
    }
}
