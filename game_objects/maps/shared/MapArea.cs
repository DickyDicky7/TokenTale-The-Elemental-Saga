using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

// Command
// Invoker
public partial class MapArea : Node3D
{
    public MapSystem
           MapSystem
    {
        get;
        set;
    }

    [Export]
    public Array<Marker3D>
                Entrances
    {
        get;
        set;
    }

    [Export]
    public Array<MapExitsToCommandSwitchMapArea>
                 MapExitsToCommandSwitchMapArea
    {
        get;
        set;
    }

    public void Setup()
    {
        foreach (MapExitsToCommandSwitchMapArea map in
                 MapExitsToCommandSwitchMapArea)
        {
            map.Agent   =   this;
            map.CommandSwitchMapArea.MapSystem =
                                     MapSystem ;
            map.ConnectSignals();
        }
    }
}





