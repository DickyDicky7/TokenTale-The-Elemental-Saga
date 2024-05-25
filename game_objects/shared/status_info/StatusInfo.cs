using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

public partial class StatusInfo : Node3D
{
    [Export]
    public Array<StatusInfoItem>
                           Items
    {
        get;
        set;
    } = [ ];

    [Export]
    public Sprite3D
           Sprite3D
    {
        get;
        set;
    }

    [Export]
    public Label
           Label
    {
        get;
        set;
    }

    [Export]
    public Timer
           Timer
    {
        get;
        set;
    }

    //public Tween
    //       tween;

    [Export]
    public Vector3 StartPosition { get; set; } = new(0.0f, 0.5f, 0.0f);
    [Export]
    public Vector3 CeasePosition { get; set; } = new(0.0f, 1.0f, 0.0f);
    [Export]
    public double Delaying { get; set; } = 0.5d;
    [Export]
    public double Duration { get; set; } = 0.5d;
    [Export]
    public Tween.      EaseType EasingfuncType { get; set; } = Tween.      EaseType.InOut;
    [Export]
    public Tween.TransitionType TransitionType { get; set; } = Tween.TransitionType.Quint;


    public override void _Ready()
    {
        base._Ready();
        Timer.WaitTime     =      Delaying;
        Timer.    Timeout += Timer_Timeout;
    }

    private void Timer_Timeout()
    {
        if (Items.Count != 0)
        {
            Tween tween  = CreateTween();
            StatusInfoItem statusInfoItem = Items[0];

            tween.TweenCallback(Callable.From(() =>
            {
                Sprite3D.Show();
                Sprite3D.Position = StartPosition;
                Label.Text = statusInfoItem.Thing;
                Label.AddThemeColorOverride   (        "font_color", statusInfoItem.FontColor       );
                Label.AddThemeColorOverride   ("font_outline_color", statusInfoItem.FontColorOutline);
                Label.AddThemeFontSizeOverride
                (   "font_size", statusInfoItem.FontSize       );
                Label.AddThemeConstantOverride
                ("outline_size", statusInfoItem.FontSizeOutline);
            }));

            tween.TweenProperty(Sprite3D  ,
                               "position" , CeasePosition, Duration)
                 .SetEase (EasingfuncType)
                 .SetTrans(TransitionType);

            tween.TweenCallback(Callable.From(() =>
            {
                Sprite3D.Hide();
            }));

            Items.
        RemoveAt(0)
               ;
        }
    }
}










