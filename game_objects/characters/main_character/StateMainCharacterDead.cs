using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterDead : State
{
    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Components @@")]
    public AnimationTree
           AnimationTree
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Components @@")]
    public AudioStreamPlayer
           AudioStreamPlayer
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Components @@")]
    public AudioStream
           AudioStream
    {
        get;
        set;
    }

    [Export]
    [ExportGroup("Components @@")]
    public HitsFlashingByModulateGlowVersion
           HitsFlashingByModulateGlowVersion
    {
        get;
        set;
    }

    public override void _Enter()
    {
                    base._Enter();

        HitsFlashingByModulateGlowVersion.PlayDeadEffect(duration: 0.5f, timeStep: 0.1f, firstActive: false);
        AnimationTree.Set
("parameters/STATE/transition_request", "DEAD");

        AudioStreamPlayer.Stream =
        AudioStream              ;
        AudioStreamPlayer.Play( );

    }

}
