using Godot;

namespace TokenTaleTheElementalSaga;

public partial class CommandSwitchMapAreaOneToOne : Command
{
    [Export]
    public MapSystem.AvailableMapArea
                          NextMapArea
    {
        get;
        set;
    } // Parameter

    public MapSystem
           MapSystem
    {
        get;
        set;
    } // Receiver

    [Export]
    public int
           EntranceIdx
    {
        get;
        set;
    }

    public override void Execute()
    {
        MapSystem.SwitchToMapArea(
                      NextMapArea ,
                      EntranceIdx);
    }
}



