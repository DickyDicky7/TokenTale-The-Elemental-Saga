using Godot;

namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Camera3D_02 : Camera3D
#pragma warning restore IDE1006 // Naming Styles
{
    public bool IsZoomedIn { get; set; } = false;

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);

        if (@inputEvent.IsMousePressed(MouseButton.WheelUp  ))
        {
            Fov -= 1.0f;
        }
        if (@inputEvent.IsMousePressed(MouseButton.WheelDown))
        {
            Fov += 1.0f;
        }
        if (@inputEvent.IsKeyboardPressed(Key.Z))
        {
            Vector3 destination;
                IsZoomedIn =
               !IsZoomedIn ;
            if (IsZoomedIn)
            {
                destination = new Vector3(0.0f, 1.5f, 1.5f);
            }
            else
            {
                destination = new Vector3(0.0f, 2.0f, 2.0f);
            }
            Tween tween = CreateTween();
            tween.TweenProperty(this, "position", destination, 0.5d);
            tween.SetEase (Tween.      EaseType.    Out)
                 .SetTrans(Tween.TransitionType.Elastic);

        }
    }

    [Export]
    public Node3D FollowTarget { get; set; }
    public 
   Vector3 Offset              { get; set; }

    public override void _Ready()
    {
                    base._Ready();

           Offset   =   Position ;
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        float x = Mathf.Lerp(GlobalPosition.X, FollowTarget.GlobalPosition.X           , 0.1f);
        float y = Mathf.Lerp(GlobalPosition.Y, FollowTarget.GlobalPosition.Y + Offset.Y, 0.1f);
        float z = Mathf.Lerp(GlobalPosition.Z, FollowTarget.GlobalPosition.Z + Offset.Z, 0.1f);
        GlobalPosition =
        GlobalPosition with
        {
            X = x,
            Y = y,
            Z = z,
        };
    }
}


















