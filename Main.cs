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

    [Export]
    public NavigationRegion3D NavigationRegionSstatic { get; set; }
    [Export]
    public NavigationRegion3D NavigationRegionDynamic { get; set; }
    [Export]
    public Timer Timer { get; set; }

    [Export]
    public StatusInfo
           StatusInfo
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready();
        
        Timer.Timeout +=
        Timer_Timeout ;
    }

    private void Timer_Timeout()
    {
        NavigationRegionSstatic.BakeNavigationMesh();
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        //GD.Print(Engine.GetFramesPerSecond());

GetWindow().Title=
                $"{Engine.GetFramesPerSecond()}";

        if (Input.IsActionJustPressed("R_CLICK"))
        {
            Ability3D ability = Scene.Instantiate<
            Ability3D>();
            Vector3        globalMousePosition = this.GetGlobalMousePosition();
            ability.Attach                       (
            spacex:        NavigationRegionSstatic,
            caster:        MainCharacter          ,
            startPosition: MainCharacter          .
           GlobalPosition,
            ceasePosition: globalMousePosition   );

            MainCharacter.
            MainCharacterAnimatedSprite3DEffect.CurrentEffect=
            MainCharacterAnimatedSprite3DEffect.       Effect.
            EFFECT_FIRE  ;

            StatusInfo
                .Items
                .Add(new StatusInfoItemElemental()
                {
                    Element = Global.Element.Ice,
                    Thing =
@$"Right Click",
                });
        }
    }
}












