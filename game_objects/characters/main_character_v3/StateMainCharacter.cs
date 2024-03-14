using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StateMainCharacter : State
{
    [Export(PropertyHint.NodeType)]
    public MainCharacter MainCharacter { get; set; }
}
