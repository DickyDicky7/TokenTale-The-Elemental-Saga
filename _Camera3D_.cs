using Godot;

namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Camera3D_ : Camera3D
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
}
