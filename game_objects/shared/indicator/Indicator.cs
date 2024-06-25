using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Indicator : Node3D
{
    [Export]
public         Color Modulate
    {
        get => Sprite.Modulate        ;
        set => Sprite.Modulate = value;
    }

    [Export]
public Sprite3D
       Sprite
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready() ;

        ProcessMode     =
        ProcessModeEnum . Disabled;
    }
}




















