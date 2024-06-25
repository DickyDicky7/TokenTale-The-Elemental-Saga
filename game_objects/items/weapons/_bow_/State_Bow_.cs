using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class State_Bow_ : State
{
    [Export(PropertyHint.NodeType)]
#pragma warning disable IDE1006 // Naming Styles
    public _Bow_ _Bow_ { get; set; }
#pragma warning restore IDE1006 // Naming Styles
}
