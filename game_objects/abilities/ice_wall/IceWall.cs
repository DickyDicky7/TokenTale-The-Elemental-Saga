using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool]
public partial class IceWall : Node3D
{
    [Export]
    public  GenerationStrategy
            GenerationStrategy
    {
        get;
        set;
    }

    [Export]
    public  Node3D
            Caster
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready();

        if (GenerationStrategy != null)
        {
            GenerationStrategy.Generate(this);
        }
    }
}
