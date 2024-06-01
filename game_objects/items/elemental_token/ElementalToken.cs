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





