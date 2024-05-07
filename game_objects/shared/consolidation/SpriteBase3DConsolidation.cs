using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool       ]
[GlobalClass]
public partial class SpriteBase3DConsolidation : Node
{
    [Export]
    public Array<SpriteBase3D> Sprites { get; set; }

    [Export]
    public     Vector3    RotationDegrees
    {
        get => Sprites[0].RotationDegrees;
        set
        {
            foreach        (
               SpriteBase3D
               sprite
            in Sprites     )
            {
               sprite    .RotationDegrees = value;
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
