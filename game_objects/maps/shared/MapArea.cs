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
    } = [ ];

    [Export]
    public Array<MapExitsToCommand>
                 MapExitsToCommand
    {
        get;
        set;
    } = [ ];

    [Export]
    public Array<MapSpawnAreaToCommand>
                 MapSpawnAreaToCommand
    {
        get;
        set;
    } = [ ];

    public void Setup()
    {
        foreach (MapExitsToCommand map in
                 MapExitsToCommand)
        {
            map.Initial       (    MapSystem , this    );
            map.ConnectSignals(                        );
        }
        foreach (MapSpawnAreaToCommand
                 map         in
                 MapSpawnAreaToCommand)
        {
            map.Initial       (    MapSystem , this    );
            map.ConnectSignals(                        );
        }
    }
}












