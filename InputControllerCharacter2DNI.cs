using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class InputControllerCharacter2DNI : InputControllerCharacter2D
{
    ///<summary>Not normalized yet</summary>
    public override Vector2 MovingDirection2D => Input.GetVector("L", "R", "U", "D");

    ///<summary>Not normalized yet</summary>
    public override Vector2 SeeingDirection2D =>
        Character2D.GetLocalMousePosition();

    public override bool ShouldDash =>
    Input.IsActionJustPressed("SPACE");

    public override bool ShouldMove =>
    Input.IsActionPressed("L") ||
    Input.IsActionPressed("R") ||
    Input.IsActionPressed("U") ||
    Input.IsActionPressed("D");
}
