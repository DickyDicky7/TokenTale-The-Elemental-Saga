using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterDead : State
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
