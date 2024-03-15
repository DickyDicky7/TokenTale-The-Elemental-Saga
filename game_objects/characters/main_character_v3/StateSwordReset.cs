using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateSwordReset : StateSword
{
    [Export]
    [ExportGroup("Transition To")]
    public State SlashState { get; set; }

    private Tween _tween;

    public override void _Enter()
    {
                    base._Enter();

        Sword.IsInUse  = false;
        Sword.Rotation = 0.00f;
        Sword.AnimationPlayer_.Play("RESET");
        Sword.CollisionShape2D.SetDeferred("disabled", true);
    }

    public override void _Leave()
    {
                    base._Leave();

        _tween.Clear();
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if ( @inputEvent.IsMousePressed
           ( MouseButton.Left))
        {
             ChangeState(SlashState);
        }
    }

    public override void _Process(double @delta)
    {
                    base._Process(      @delta);

        Vector2 hover_Position  = Sword.GetLocalMousePosition();
        Vector2 inputDirection  = Extension
            .GetInputDirection();
        if    ( inputDirection !=
        Vector2.Zero)
        {
            hover_Position = inputDirection;
        }
            Sword.Sprite2D.FlipH = Mathf.RadToDeg(
            hover_Position.Angle())
        switch
        {
            > -135.0f and <= +045.0f => !false,
            _                        =>  false,
        };
        Vector2 offset;
        if (Sword.Sprite2D.FlipH)
        {
            offset = Sword.Sprite2D.Offset with { X = -Mathf.Abs(Sword.DefaultOffsetSprite2D.X) };
        }
        else
        {
            offset = Sword.Sprite2D.Offset with { X = +Mathf.Abs(Sword.DefaultOffsetSprite2D.X) };
        }
        _tween = Sword.CreateTween();
        _tween.SetLoops(1);
        _tween.TweenProperty(Sword.Sprite2D, "offset", offset, 0.5d)
              .SetEase (Tween.      EaseType.OutIn)
              .SetTrans(Tween.TransitionType.Quint);
         Sword.ZIndex = Mathf.RadToDeg(hover_Position.Angle())
        switch
        {
            > -135.0f and <= +045.0f => -1,
            _                        => +1,
        };
    }
}
