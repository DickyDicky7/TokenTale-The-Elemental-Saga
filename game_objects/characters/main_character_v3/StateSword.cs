using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StateSword : State
{
    [Export(PropertyHint.NodeType)]
    public Sword Sword { get; set; }
}
