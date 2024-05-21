using Godot ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
// Concrete
// Command&  Context ( of Strategy )
public partial class CommandSwitchMapArea : Command
{
    public MapSystem
           MapSystem
    {
        get;
        set;
    } // Receiver of Command

    [Export]
    public StrategySwitchMapArea
           StrategySwitchMapArea
    {
        get;
        set;
    } // Abstract
      // Strategy

    public override void         Execute(         )
    {
           StrategySwitchMapArea.Execute(MapSystem);
    }

    public override void         Initial(params object[] @objects)
    {
           MapSystem =                                   @objects
[0] as     MapSystem ;
    }
}























