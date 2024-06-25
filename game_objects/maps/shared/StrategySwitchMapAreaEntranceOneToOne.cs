using Godot ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
// Concrete
// Strategy
public partial class StrategySwitchMapAreaEntranceOneToOne :
                     StrategySwitchMapAreaEntrance
{
    [Export]
    public int
           EntranceIdx
    {
        get;
        set;
    }

    public override void Execute(MapSystem @mapSystem)
    {
                                           @mapSystem.SwitchToMapAreaEntrance
          (
           EntranceIdx
          )           ;
    }
}















