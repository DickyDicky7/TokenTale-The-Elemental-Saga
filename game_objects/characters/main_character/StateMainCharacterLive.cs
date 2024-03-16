using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterLive : State
{
    [Export]
    [ExportGroup("Components @@")]
    public MainCharacter
       MainCharacter
    {
        get;
        set;
    }
}
