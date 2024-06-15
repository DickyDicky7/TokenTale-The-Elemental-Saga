using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterHurt : State
{
    [Export]
    [ExportGroup("Transition ##")]
    public State SafeState { get; set; }

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

        HitsFlashingByModulateGlowVersion.PlayHurtEffect(duration: 1.0f, timeStep: 0.1f, firstActive: false);
        Tween tween =
MainCharacter.        CreateTween();
        tween.TweenCallback(
                   Callable.From(() => ChangeState(SafeState)))
             .     SetDelay( 1.0f );

        AudioStreamPlayer.Stream =
        AudioStream              ;
        AudioStreamPlayer.Play( );

    }
}









