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

    public static bool IsLMousePressed(this InputEvent @inputEvent)
    {
        return @inputEvent is not null
            && @inputEvent is
                InputEventMouseButton
                inputEventMouseButton
            &&  inputEventMouseButton.Pressed
            &&  inputEventMouseButton.ButtonIndex is MouseButton.Left;
    }

    public static Vector2 GetInputDirection()
    {
        return Input.GetVector("L", "R", "U", "D");
    }

    public static void Insert(this Array<State>
        @activeComponentStates, State @newComponentState)
    {
        @activeComponentStates.Add(@newComponentState);
    }
}

