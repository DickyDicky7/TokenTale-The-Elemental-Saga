using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

public partial class ElementalToken : Item3D
{
    [Export]
    public Global.Element
                  Element
    {
        get;
        set;
    }

    [Export]
    public Sprite3D
           Sprite3D
    {
        get;
        set;
    }

    [Export]
    public Sprite3D
           Shadow3D
    {
        get;
        set;
    }

    [Export]
    public Array<Material> Materials
    {
        get;
        set;
    } = [ ];

    [Export]
    public Area3D
           Hitbox
    {
        get;
        set;
    }
    private double ExistTime { get; set; } = 7.5d;
    private Timer ExistTimer { get; set; } = new();
    public override void _Ready()
    {
                    base._Ready();

        Hitbox.BodyEntered +=
        Hitbox_BodyEntered;

        int index =
       (int)Element;

        if (index <                     Materials.Count)
        {
            Sprite3D.MaterialOverride = Materials[index];
//          Shadow3D.MaterialOverride = Materials[index];
        }
        this.ExistTimer.ProcessCallback = Timer.TimerProcessCallback.Physics;
        this.ExistTimer.OneShot = true;
        this.AddChild(this.ExistTimer);
        this.ExistTimer.Start(this.ExistTime);
        this.ExistTimer.Timeout += OnTimerTimeout;
    }
    private void OnTimerTimeout()
    {
        this.QueueFree();
    }

    private void Hitbox_BodyEntered(Node3D @body)
    {
        if (@body
        is  MainCharacter
            mainCharacter
           )
        {

        }
    }
}





