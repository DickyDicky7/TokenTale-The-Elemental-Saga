using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class InputControllerCharacter2D : Node
{
    public abstract Vector2 MovingDirection2D { get; }
    public abstract Vector2 SeeingDirection2D { get; }
    public abstract bool ShouldDash { get; }
    public abstract bool ShouldMove { get; }

    [Export(PropertyHint.NodeType)]
    public Character2D Character2D
    { get; set; }
}
