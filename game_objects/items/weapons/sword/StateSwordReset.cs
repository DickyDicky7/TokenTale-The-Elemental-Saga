using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateSwordReset : StateSword
{
    [Export]
    [ExportGroup("Transition ##")]
    public State SlashState { get; set; }

    private Tween _tween;

    public override void _Enter()
    {
                    base._Enter();

        Sword.IsInUse  = false;
        Sword.AnimationPlayerr.Play("RESET");
        Sword.CollisionShape3D.SetDeferred("disabled", true);
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

        Vector2 hover_Position  = Sword .Get_LocalMousePosition().ConvertToTopDown();
//      Vector2 hover_Position  = Sword .GetScreenMousePosition()                   ;
        Vector2 inputDirection  = Extension
        .    GetInputDirection();
        if    ( inputDirection !=
        Vector2.Zero)
        {
            hover_Position = inputDirection;
        }
            Sword.Sprite3D.FlipH = Mathf.RadToDeg(
            hover_Position.Angle())
        switch
        {
            > -135.0f and <= +045.0f => !false,
            _                        =>  false,
        };
            Sword.Shadow3D.FlipH =
            Sword.Sprite3D.FlipH ;
        Vector2 offset;
        if (Sword.Sprite3D.FlipH)
        {
            offset = Sword.Sprite3D.Offset with { X = -Mathf.Abs(Sword.DefaultOffsetSprite3D.X), };
        }
        else
        {
            offset = Sword.Sprite3D.Offset with { X = +Mathf.Abs(Sword.DefaultOffsetSprite3D.X), };
        }
        _tween = Sword.CreateTween();
        _tween.SetLoops(1);
        _tween.TweenProperty(Sword.Sprite3D, "offset", offset, 0.5d)
              .SetEase (Tween.      EaseType.OutIn)
              .SetTrans(Tween.TransitionType.Quint)  ;
        _tween.SetParallel();
        _tween.SetLoops(1);
        _tween.TweenProperty(Sword.Shadow3D, "offset", offset, 0.5d)
              .SetEase (Tween.      EaseType.OutIn)
              .SetTrans(Tween.TransitionType.Quint)  ;
        int
        renderPriority =Mathf.RadToDeg(hover_Position.Angle())
        switch
        {
            > -135.0f and <= +045.0f => -1,
            _                        => +1,
        };
        Sword.        Sprite3D.MaterialOverride.RenderPriority = renderPriority;
        Sword.        Shadow3D                 .RenderPriority = renderPriority;
        Sword.AnimatedSprite3D.MaterialOverride.RenderPriority = renderPriority;
        Sword.AnimatedShadow3D                 .RenderPriority = renderPriority;
    }
}






