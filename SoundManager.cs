using     Godot                    ;

namespace TokenTaleTheElementalSaga;

public partial class SoundManager  :  Node
{
    protected AudioStreamPlayer AudioStreamPlayer1 { get; set; }
    protected AudioStreamPlayer AudioStreamPlayer2 { get; set; }

    public override void _Ready()
    {
                    base._Ready();

        AudioStreamPlayer1 = new(  );
        AudioStreamPlayer2 = new(  );
        AddChild(AudioStreamPlayer1);
        AddChild(AudioStreamPlayer2);
        //AudioStreamPlayer1.Set("parameters/looping", true);
        //AudioStreamPlayer2.Set("parameters/looping", true);
    }

    public void CrossfadeTo(AudioStream @audioStream)
    {
        if (AudioStreamPlayer1.Playing
        &&  AudioStreamPlayer2.Playing)
        {
            return;
        }

        if (AudioStreamPlayer2.Playing)
        {
            AudioStreamPlayer1.Stream = @audioStream;
            AudioStreamPlayer1.VolumeDb = -80.0f;
            AudioStreamPlayer2.VolumeDb = +00.0f;

            Tween tween = CreateTween();
            tween.TweenCallback(Callable.From(() => AudioStreamPlayer1.Play()));
            tween.TweenProperty(AudioStreamPlayer1, "volume_db", +00.0f, 0.5d)
                 .SetEase(Tween.EaseType.@In).SetTrans(Tween.TransitionType.Sine);
            tween.Parallel();
            tween.TweenProperty(AudioStreamPlayer2, "volume_db", -80.0f, 0.5d)
                 .SetEase(Tween.EaseType.Out).SetTrans(Tween.TransitionType.Sine);
            tween.TweenCallback(Callable.From(() => AudioStreamPlayer2.Stop()));
        }
        else
        {
            AudioStreamPlayer2.Stream = @audioStream;
            AudioStreamPlayer2.VolumeDb = -80.0f;
            AudioStreamPlayer1.VolumeDb = +00.0f;

            Tween tween = CreateTween();
            tween.TweenCallback(Callable.From(() => AudioStreamPlayer2.Play()));
            tween.TweenProperty(AudioStreamPlayer2, "volume_db", +00.0f, 0.5d)
                 .SetEase(Tween.EaseType.@In).SetTrans(Tween.TransitionType.Sine);
            tween.Parallel();
            tween.TweenProperty(AudioStreamPlayer1, "volume_db", -80.0f, 0.5d)
                 .SetEase(Tween.EaseType.Out).SetTrans(Tween.TransitionType.Sine);
            tween.TweenCallback(Callable.From(() => AudioStreamPlayer1.Stop()));

        }
    }

    public void GoSilence()
    {
        AudioStreamPlayer1.Stop();
        AudioStreamPlayer2.Stop();
    }
}









