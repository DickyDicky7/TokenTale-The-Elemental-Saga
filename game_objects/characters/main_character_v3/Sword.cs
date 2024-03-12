using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

//[GlobalClass]
public partial class Sword : Weapon
{
    [Export]
    public Sprite2D
           Sprite2D
    {
        get;
        set;
    }

    [Export]
    public CollisionShape2D
           CollisionShape2D
    {
        get;
        set;
    }

    [Export]
    public AnimatedSprite2D
           AnimatedSprite2D
    {
        get;
        set;
    }

    [Export]
    public AnimationPlayer
           AnimationPlayer_
    {
        get;
        set;
    }

    [Export] public Node NodeStateChart
    {
        get => null;
        set => _stateChart = StateChart.Of(value);
    }

    private int _slashCount;
    private Vector2 _defaultOffsetSprite2D;
    private Tween      _tween1    ;
    private Tween      _tween2    ;
    private Tween      _tween3    ;
    private StateChart _stateChart;

    public override void _Ready()
    {
                    base._Ready()  ;
        _defaultOffsetSprite2D = Sprite2D.Offset;
    }


    #region RESET STATE
    private void OnResetStateEntered()
    {
        Rotation = 0.0f;
        AnimationPlayer_.Play("RESET");
        CollisionShape2D.SetDeferred("disabled", !false);
    }

    private void OnResetStateExited_()
    {
        _tween1.Clear();
        _tween2.Clear();
        _tween3.Clear();
    }

    private void OnResetState_Input_(InputEvent @inputEvent)
    {
        if (   @inputEvent
        is      InputEventMouseButton
                inputEventMouseButton)
        {
            if (inputEventMouseButton
            .Pressed
            &&  inputEventMouseButton.ButtonIndex
            is            MouseButton.Left          )
            {
                _stateChart.SendEvent("ToSlashState");
            }
        }
    }

    private void OnResetStatePhysicsProcessing(float @delta)
    {
        Vector2 toPos = GetLocalMousePosition();
        Vector2 toDir
        = Input.GetVector( "L", "R", "U", "D" );
        if (toDir != Vector2.Zero)
        {
            toPos  =
            toDir  ;
        }
            Sprite2D.FlipH = Mathf.RadToDeg(toPos.Angle()) switch
        {
            > -135.0f and <= +045.0f => !false,
            _                        =>  false,
        };
        Vector2 offset;
        if (Sprite2D.FlipH)
        {
            offset = Sprite2D.Offset with { X = -Mathf.Abs(_defaultOffsetSprite2D.X) };
        }
        else
        {
            offset = Sprite2D.Offset with { X = +Mathf.Abs(_defaultOffsetSprite2D.X) };
        }
        _tween2 = CreateTween();
        _tween2.SetLoops(1);
        _tween2.TweenProperty(Sprite2D, "offset", offset, 0.5d)
               .SetEase (Tween.      EaseType.OutIn)
               .SetTrans(Tween.TransitionType.Quint);
        ZIndex = Mathf.RadToDeg(toPos.Angle()) switch
        {
            > -135.0f and <= +045.0f => -1,
            _                        => +1,
        };
    }
    #endregion


    #region SLASH STATE
    private void OnSlashStateEntered()
    {
        Vector2 toDir =  Input
        .GetVector("L", "R", "U", "D");
        if    ( toDir == Vector2.Zero)
        {
            AnimatedSprite2D.FlipH = GetLocalMousePosition().X switch
            {
                <= 0 => !false,
                >  0 =>  false,
                _    =>  false,
            };
            LookAt(GetGlobalMousePosition
                ());
        }
        else
        {
            AnimatedSprite2D.FlipH  =
                       toDir.X switch
            {
                <= 0 => !false,
                >  0 =>  false,
                _    =>  false,
            };
            Rotation = toDir.Angle();
        }
        CollisionShape2D.SetDeferred("disabled",  false);
        AnimationPlayer_.Play($"SLASH_{_slashCount}"   );
        _slashCount++;
        _slashCount %= 4;
    }

    private void OnSlashStateExited_()
    {
        _tween1.Clear();
        _tween2.Clear();
        _tween3.Clear();
    }
    #endregion


    private void OnAnimationPlayer_AnimationCease(StringName @animationName)
    {
        switch (@animationName)
        {
            case "SLASH_0":
            case "SLASH_1":
            case "SLASH_2":
            case "SLASH_3":
                _stateChart.SendEvent("ToResetState");
                break;
        }
    }
}
