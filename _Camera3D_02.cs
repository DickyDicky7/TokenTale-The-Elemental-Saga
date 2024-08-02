using        Godot        ;
using Vect = Godot.Vector3;

namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Camera3D_02 : Camera3D
#pragma warning restore IDE1006 // Naming Styles
{
    public bool IsZoomedIn { get; set; } = false;
    public Vect   Offset   { get; set; }
    public Vect   OffsetTo { get; set; }
    public Vect                         RotationDegreesTo { get; set; }

    [Export]
    public Tween.TransitionType
           TType { get; set; }
    [Export]
    public Tween.      EaseType
           EType { get; set; }
    [Export]
    public Node3D
    @FollowTarget
    { get; set; }
    [Export]
    public float LerpWeight { get; set; } = 01.0f;
    [Export]
    public float FovWhenHasZoomedIn { get; set; } = 65.0f;
    [Export]
    public float FovWhenNotZoomedIn { get; set; } = 75.0f;
    [Export]
    public double @DurationZoomedIn { get; set; } = 00.1d;

    [Export]
    public MapSystem
           MapSystem
    {
        get;
        set;
    }

    [Export]
    public float        ShakeFade     { get; set; } = 5.0f;
    [Export]
    public float        ShakeStrength { get; set; } = 0.1f;
    public float CurrentShakeStrength { get; set; } = 0.0f;

    public override void _Ready()
    {
                    base._Ready()  ;

        Offset = Position          ;
        Fov    = FovWhenNotZoomedIn;
                 OffsetTo =          Offset;
        RotationDegreesTo = RotationDegrees;
    }

    public override void _Input(InputEvent @event)
    {
                    base._Input(           @event);

        if (@event.IsMousePressed(MouseButton.WheelDown))
        {
            Projection = ProjectionType.@Orthogonal;
        }
        if (@event.IsMousePressed(MouseButton.WheelUp  ))
        {
            Projection = ProjectionType.Perspective;
        }
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        if (Input.IsActionPressed("U")
        ||  Input.IsActionPressed("D")
        ||  Input.IsActionPressed("L")
        ||  Input.IsActionPressed("R"))
        {
            if (!IsZoomedIn)
            {
                Tween tween =
                CreateTween();
                tween.TweenProperty(this, "fov", FovWhenHasZoomedIn, @DurationZoomedIn)
                     .SetEase (EType)
                     .SetTrans(TType);
            }
                 IsZoomedIn = true;
        }
        else
        {
            if ( IsZoomedIn)
            {
                Tween tween =
                CreateTween();
                tween.TweenProperty(this, "fov", FovWhenNotZoomedIn, @DurationZoomedIn)
                     .SetEase (EType)
                     .SetTrans(TType);
            }
                 IsZoomedIn =!true;
        }

        if (Input.IsActionJustPressed("Q"))
        {
                     OffsetTo = Offset.Rotated(Vect.Down, +Mathf.DegToRad(45));
            RotationDegreesTo = RotationDegrees with { Y = RotationDegrees.Y - 45 };
        }
        else
        if (Input.IsActionJustPressed("E"))
        {
                     OffsetTo = Offset.Rotated(Vect.Down, -Mathf.DegToRad(45));
            RotationDegreesTo = RotationDegrees with { Y = RotationDegrees.Y + 45 };
        }

        if (CurrentShakeStrength > 0)
        {
            CurrentShakeStrength = Mathf.Lerp(CurrentShakeStrength, 0.0f, ShakeFade * (float)@delta);
            Vector2   offset     =            RandomOffset();
            HOffset = offset.X;
            VOffset = offset.Y;
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        if (!IsInstanceValid(@FollowTarget        )
        ||                   @FollowTarget is null)
            return;

        //Vector2 cameraSize = (Vector2)GetWindow().Size * 0.01f;

        float x = Mathf.Lerp(GlobalPosition.X, @FollowTarget.GlobalPosition.X + Offset.X, LerpWeight);
        float y = Mathf.Lerp(GlobalPosition.Y, @FollowTarget.GlobalPosition.Y + Offset.Y, LerpWeight);
        float z = Mathf.Lerp(GlobalPosition.Z, @FollowTarget.GlobalPosition.Z + Offset.Z, LerpWeight);

        if (MapSystem != null)
        {
            x = Mathf.Clamp(x, MapSystem.BoundingBox.Position.X + OffsetLimitAxisX.X, MapSystem.BoundingBox.End.X + OffsetLimitAxisX.Y);
            z = Mathf.Clamp(z, MapSystem.BoundingBox.Position.Z + OffsetLimitAxisZ.X, MapSystem.BoundingBox.End.Z + OffsetLimitAxisZ.Y);
        }

        GlobalPosition =
        GlobalPosition with
        {
            X = x,
            Y = y,
            Z = z,
        };

                 Offset =          OffsetTo;
        RotationDegrees = RotationDegreesTo;
    }

    [Export]
    public Vector2 OffsetLimitAxisX { get; set; } = new( +1 , -1 );
    [Export]
    public Vector2 OffsetLimitAxisZ { get; set; } = new( -1 , +1 );

    public void ApplyShake()
    {
    CurrentShakeStrength =
           ShakeStrength ;
    }

    public Vector2 RandomOffset()
    {
        return new((float)GD.RandRange( -CurrentShakeStrength , +CurrentShakeStrength ),
                   (float)GD.RandRange( -CurrentShakeStrength , +CurrentShakeStrength));
    }
}




































