using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterLive : State
{
    [Export]
    [ExportGroup("Transition ##")]
    public State DeadState { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }


    public override void _Enter()
    {
                    base._Enter()    ;

           MainCharacter.HealthChange +=
           MainCharacter_HealthChange;
    }

    public override void _Leave()
    {
                    base._Leave() ;

        MainCharacter.HealthChange -=
        MainCharacter_HealthChange;
    }

    private void MainCharacter_HealthChange(float @damage)
    {
        if (     MainCharacter.             CurrentHealth <= 0.0f)
        {
            ChangeState(DeadState);
        }
    }
}



