using        Godot        ;
using Vect = Godot.Vector3;

namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Camera3D_02 : Camera3D
#pragma warning restore IDE1006 // Naming Styles
{
    public bool IsZoomedIn { get; set; } = false;
    public Vect   Offset   { get; set; }

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

    public override void _Ready()
    {
                    base._Ready()  ;

        Offset = Position          ;
        Fov    = FovWhenNotZoomedIn;
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
                tween.TweenProperty(this, "fov", FovWhenHasZoomedIn, 0.5d)
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
                tween.TweenProperty(this, "fov", FovWhenNotZoomedIn, 0.5d)
                     .SetEase (EType)
                     .SetTrans(TType);
            }
                 IsZoomedIn =!true;
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        if (FollowTarget is null)
            return;

        float x = Mathf.Lerp(GlobalPosition.X, FollowTarget.GlobalPosition.X           , LerpWeight);
        float y = Mathf.Lerp(GlobalPosition.Y, FollowTarget.GlobalPosition.Y + Offset.Y, LerpWeight);
        float z = Mathf.Lerp(GlobalPosition.Z, FollowTarget.GlobalPosition.Z + Offset.Z, LerpWeight);
        GlobalPosition =
        GlobalPosition with
        {
            X = x,
            Y = y,
            Z = z,
        };
    }
}























