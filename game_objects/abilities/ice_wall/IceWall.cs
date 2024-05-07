using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool]
public partial class IceWall : Ability3D
{
    [Export]
    public  GenerationStrategy
            GenerationStrategy
    {
        get;
        set;
    }

    //[Export]
    //public  Node3D
    //        Caster
    //{
    //    get;
    //    set;
    //}

    public override void _Ready()
    {
                    base._Ready();

        if (GenerationStrategy != null)
        {
            GenerationStrategy.Generate(this);
        }
    }

    public override void ChangeVisual(Vector3 @movingDirection)
    {
                    base.ChangeVisual(        @movingDirection);

        LookAt(target: @movingDirection, up: Vector3.Up, useModelFront: false);

    }
}
