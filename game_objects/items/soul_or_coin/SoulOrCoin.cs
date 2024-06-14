using Godot;

namespace TokenTaleTheElementalSaga;

public partial class SoulOrCoin : Item3D
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
                    base._Ready()   ;

                 Hitbox.BodyEntered +=
                 Hitbox_BodyEntered ;
    }

    private void Hitbox_BodyEntered(Node3D @body)
    {
        if (@body
        is  MainCharacter
            mainCharacter
           )
        {
            mainCharacter.CurrentCoin += this.RandomizeAmountOfCoin();
            mainCharacter.EmitSignal(MainCharacter.SignalName.CoinChanged, mainCharacter.CurrentCoin);
            this.QueueFree();
        }
    }
    private int RandomizeAmountOfCoin()
    {
        RandomNumberGenerator rand = new RandomNumberGenerator();
        return rand.RandiRange(5, 15);
    }
}




