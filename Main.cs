using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Main : Node3D
{
    [Export]
    public PackedScene
                 Scene
    {
        get;
        set;
    }

    [Export]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        //GD.Print(Engine.GetFramesPerSecond());

        if (Input.IsActionJustPressed("R_CLICK"))
        {
            Ability3D ability = Scene.Instantiate<
            Ability3D>();
            Vector3        globalMousePosition = this.GetGlobalMousePosition();
            ability.Attach                       (
            spacex: this                          ,
            caster:        MainCharacter          ,
            startPosition: MainCharacter          .
           GlobalPosition,
            ceasePosition: globalMousePosition   );
        }
    }
}
