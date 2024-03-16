using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterHurt : State
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
