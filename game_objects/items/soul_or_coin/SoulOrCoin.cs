using Godot;

namespace TokenTaleTheElementalSaga;

public partial class SoulOrCoin : Node3D
{
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

        Hitbox.BodyEntered += Hitbox_BodyEntered;
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


