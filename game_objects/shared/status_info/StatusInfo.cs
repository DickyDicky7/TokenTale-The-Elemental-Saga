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
    }

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

    public Tween
           tween;

    public override void _Ready()
    {
                    base._Ready();
        Timer.Timeout += Timer_Timeout;
    }

    private void Timer_Timeout()
    {
        if (Items.Count != 0)
        {
            tween = CreateTween();
            tween.TweenCallback(Callable.From(() =>
            {
                Sprite3D.Show();
                Sprite3D.Position = new();
                Label.Text = Items[0].Thing;
                //Label.Set("theme_override_colors/font_outline_color", Items[0].Color);
            }));
            tween.TweenProperty(Sprite3D, "position", new Vector3(0.0f, 1.0f, 0.0f), 0.5d);
            tween.TweenCallback(Callable.From(() =>
            {
                Sprite3D.Hide();
            }));


            Items.RemoveAt(0);
        }
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

    }
}
