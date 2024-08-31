using     Godot                    ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StateEB : State
{
    [Export(PropertyHint.NodeType)]
    public ElementalBracelet
           ElementalBracelet
    {
        get;
        set;
    }
}
