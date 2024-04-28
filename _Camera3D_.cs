using Godot;

namespace TokenTaleTheElementalSaga;
public partial class _Camera3D_ : Camera3D
{
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
    }
}
