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

 protected Aabb    BoundingBox { get; set; }
 protected bool    Cached      { get; set; }
    public Aabb GetBoundingBox()
    {
        if       (!Cached)
        {
                   Cached      =    true;
                   BoundingBox = GetNode<StaticBody3D>
                                 (nameof(StaticBody3D)).GetChild<MeshInstance3D>(idx: 0, includeInternal: false).GetAabb();
        }
    return         BoundingBox; 
    }

    [Export]
    public MeshInstance3D
           MeshInstance3D
    {
        get;
        set;
    }
}





















