using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool       ]
[GlobalClass]
public sealed partial class LookinAtCamSpriteBase3DConsolidation : Node
{
    [Export]
    public Array<SpriteBase3D> Sprites { get; set; }
    [Export]
    public           Camera3D  Cameraa { get; set; }

    public override void _Ready()
    {
                    base._Ready();

        ProcessMode     =
        ProcessModeEnum .Disabled;

        if (Cameraa is null)
        {
            foreach        (
                SpriteBase3D
                sprite
            in  Sprites    )
            {
                sprite.LookAtActiveCamera(       );
            }
        }
        else
        {
            foreach        (
                SpriteBase3D
                sprite
            in  Sprites    )
            {
                sprite.LookAt______Camera(Cameraa);
            }
        }
    }
}
