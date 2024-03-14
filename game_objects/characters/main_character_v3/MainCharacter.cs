using Godot;
using Vector2D = Godot.Vector2;

namespace TokenTaleTheElementalSaga;

public partial class MainCharacter : Character2D
{
    [Export] public float JumpV { get; set; }
    [Export] public float Speed { get; set; }
    [Export] public Vector2D      BlendPosition { get; set; }
    [Export] public EyeSight      EyeSight      { get; set; }
    [Export] public AnimationTree AnimationTree { get; set; }
}
