using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterSafe : State
{
    [Export]
    [ExportGroup("Transition ##")]
    public State HurtState { get; set; }

    [Export]
    [ExportGroup("Transition ##")]
    public State HealState { get; set; }

    [Export]
    [ExportGroup("Components @@")]
    public EyeSight3D
           EyeSight3D
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Parameters !!")]
    public Vector2 SeeingDirection { get; set; }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        SeeingDirection = MainCharacter.Get_LocalMousePosition().ConvertToTopDown();
//      SeeingDirection = MainCharacter.GetScreenMousePosition()                   ;
        EyeSight3D
        .FollowPosition(
        SeeingDirection);
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
        if (damage > 0)
        {
            ChangeState(HurtState);
        }
        else
        {
            ChangeState(HealState);
        }
    }
}
