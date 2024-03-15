using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

public static class Extension
{
    public static void Clear(this Tween @tween)
    {
        if (@tween != null)
        {
            @tween.Stop();
            @tween.Kill();
            //@tween.Dispose();
        }
    }

    public static bool IsMousePressed(this InputEvent @inputEvent, MouseButton @buttonIndex)
    {
        return @inputEvent is not null
            && @inputEvent is
                InputEventMouseButton
                inputEventMouseButton
            &&  inputEventMouseButton.Pressed
            &&  inputEventMouseButton.ButtonIndex
            ==                       @buttonIndex;
    }

    public static Vector2 GetInputDirection()
    {
        return Input.GetVector("L", "R", "U", "D");
    }

    public static void Insert(this Array<State>
        @activeComponentStates, State @newComponentState)
    {
        @activeComponentStates. Add  (@newComponentState);
    }

    public static bool IsKeyboardPressed(this InputEvent @inputEvent, Key @keycode)
    {
        return @inputEvent is not null
            && @inputEvent is
                InputEventKey
                inputEventKey
            &&  inputEventKey.Pressed
            &&  inputEventKey.Keycode
            ==               @keycode;
    }
}

