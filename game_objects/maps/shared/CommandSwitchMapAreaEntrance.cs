using Godot ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
// Concrete
// Command&  Context ( of Strategy )
public partial class CommandSwitchMapAreaEntrance : Command
{
    public MapSystem
           MapSystem
    {
        get;
        set;
    } // Receiver of Command

    [Export]
    public StrategySwitchMapAreaEntrance
           StrategySwitchMapAreaEntrance
    {
        get;
        set;
    } // Abstract
      // Strategy

    public override void                 Execute(         )
    {
           StrategySwitchMapAreaEntrance.Execute(MapSystem);
    }

    public override void                 Initial(params object[] @objects)
    {
           MapSystem =                                           @objects
[0] as     MapSystem ;
    }
}























