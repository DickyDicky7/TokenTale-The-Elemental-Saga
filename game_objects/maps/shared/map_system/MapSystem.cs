using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

// Commands
// Receiver
public partial class MapSystem : Node
{
    public enum AvailableMapArea
    {
            BEACH_01,
            BEACH_02,
           DESERT_01,
           DESERT_02,
        GRASSLAND_01,
        GRASSLAND_02,
        GRASSLAND_03,
        GRASSLAND_04,
        GRAVEYARD_01,
        GRAVEYARD_02,
         HIGHLAND_01,
         HIGHLAND_02,
              ICE_01,
              ICE_02,
              ICE_03,
           JUNGLE_01,
           JUNGLE_02,
           JUNGLE_03,
             LAKE_01,
             LAKE_02,
         MOUNTAIN_01,
            SWAMP_01,
             TOMB_01,
             TOMB_02,
          VOLCANO_01,
    }

    [Export]
    public Array<PackedScene>
 AvailableMapAreaPackedScenes
    {
        get;
        set;
    }

    [Export]
    public Array<Character3D>
                 Characters
    {
        get;
        set;
    }

    [Export]
    public NavigationRegion3D
           MapAreaPlaceHolder
    {
        get;
        set;
    }

    [Export]
    MainCharacter MainCharacter;

    public override void _Ready()
    {
        base._Ready();

        if (MapAreaPlaceHolder.GetChildren()[0] is MapArea
                                                   mapArea)
        {
            mapArea.
            MapSystem = this;
            mapArea. Setup();
            MapAreaPlaceHolder.BakeNavigationMesh();
                   MainCharacter.GlobalPosition =
            mapArea.Entrances[0].GlobalPosition ;
        }
    }

    public void SwitchToMapArea             (
               AvailableMapArea @nextMapArea,
                            int @entranceIdx)
    {
        if (   AvailableMapAreaPackedScenes[(int)@nextMapArea]
            .Instantiate
           (   editState:   PackedScene.
                           GenEditState.
                           Disabled        )    is    MapArea
                                                      mapArea)
        {
            mapArea.
            MapSystem = this;
            mapArea. Setup();
                             MainCharacter.ProcessMode    =
                                           ProcessModeEnum.Disabled   ;
            MapAreaPlaceHolder.GetChildren()[  0  ]       .QueueFree();
            MapAreaPlaceHolder.AddChild   (mapArea);
            MapAreaPlaceHolder.BakeNavigationMesh();
                             MainCharacter.GlobalPosition =
            mapArea.Entrances[entranceIdx].GlobalPosition ;
                             MainCharacter.ProcessMode    =
                                           ProcessModeEnum.
            Inherit;
        }
    }
}











