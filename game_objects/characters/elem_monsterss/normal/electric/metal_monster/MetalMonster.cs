using Godot;

namespace TokenTaleTheElementalSaga;

public partial class MetalMonster : ElementalMonster
{
    private int   Charge       { get; set; } =   0 ;
    private float StunDuration { get; set; } = 1.0f;
    
    public override void Attack( @MainCharacter    targetMainCharacter)
    {
        CreateAbility(   nameof(MiniThunderShock), targetMainCharacter);
    }

    public override void AcceptVisitor(EnemiesVisitor visitor)
    {
        visitor.Visit(this);
    }

    public void Shock          (
                  MainCharacter
            targetMainCharacter)
    {
        if (this.Charge < 3)
        {
            this.Charge ++ ;
        }
        else
        {
            this.Charge = 0;
            targetMainCharacter.StartStun(StunDuration);
        }
    }

    public override
        void _Ready()
    {
        this.Key = "Electric01";
        base._Ready()          ;
    }
}
