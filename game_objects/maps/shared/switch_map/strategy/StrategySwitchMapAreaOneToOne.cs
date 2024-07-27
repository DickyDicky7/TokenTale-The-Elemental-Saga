using Godot ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
// Concrete
// Strategy
public partial class StrategySwitchMapAreaOneToOne :
                     StrategySwitchMapArea
{
    [Export]
    public MapSystem.AvailableMapArea
                          NextMapArea
    {
        get;
        set;
    } // Parameter (of Command)

    [Export]
    public int
           EntranceIdx
    {
        get;
        set;
    }

    public override void Execute(MapSystem @mapSystem)
    {
                                           @mapSystem.SwitchToMapArea
          (NextMapArea,
           EntranceIdx
          )           ;
    }
}















