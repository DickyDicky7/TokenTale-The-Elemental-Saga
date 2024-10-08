using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

// Commands
// Receiver
public partial class MapSystem : Node
{
    [Export]
    public Environment
           Environment
    {
        get;
        set;
    }

    [Export]
    public DirectionalLight3D
           DirectionalLight3D
    {
        get;
        set;
    }

    [Export]
    public Node ScreenTransition { get; set; }

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
    } = [ ];

    [Export]
    public Array<Color>
    @AmbientLightColors
    {
        get;
        set;
    } = [ ];

    [Export]
    public Array< AudioStream >
           AmbientAudioStreams
    {
        get;
        set;
    } = [ ];

    [Export]
    public Array<Character3D>
                 Characters
    {
        get;
        set;
    } = [ ];

    [Export]
    public NavigationRegion3D
           MapAreaPlaceHolder
    {
        get;
        set;
    }

    [Export]
    public MainCharacter
           MainCharacter
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready();

        if (MapAreaPlaceHolder.GetChildren()[0] is MapArea
                                                   mapArea)
        {
            mapArea.
            MapSystem = this;
            mapArea. Setup();
            MapAreaPlaceHolder.    NavigationMesh.Clear();
            MapAreaPlaceHolder.BakeNavigationMesh      ();
                   MainCharacter.GlobalPosition =
            mapArea.Entrances[0].GlobalPosition ;

                  AvailableMapArea
                    currentMapArea =
System.Enum.Parse<AvailableMapArea>(
                  ((string)mapArea.Name).ToUpper().Insert(
                  ((string)mapArea.Name).Length - 2 , "_"));

        Environment.AmbientLightColor
                   =AmbientLightColors[(int)currentMapArea];


            GetNode<DropManager>("/root/DropManager")
                   .                        CurrentMapArea
                   =                        currentMapArea ;

            CurrentMapArea =
                   mapArea ;

            GetNode<SoundManagerBGMAmbient>  (
    $"/root/{nameof(SoundManagerBGMAmbient)}").CrossfadeTo(AmbientAudioStreams[(int)currentMapArea]);

            if (         MaterialApplying)
                   mapArea.MeshInstance3D.Mesh.SurfaceSetMaterial(
                                                      0, Material);

            if (SkyShaderMaterialApplying)
              @Environment.Sky.SkyMaterial  =  @SkyShaderMaterial ;
        }

        //
MainCharacter.NavigationRegion3DStatic = MapAreaPlaceHolder;
    }

    public async void SwitchToMapArea       (
               AvailableMapArea @nextMapArea,
                            int @entranceIdx)
    {
try
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
                                           ProcessModeEnum.Disabled;
            Node node = MapAreaPlaceHolder.@GetChildren()[0]       ;
  await ToSignal(node.GetTree(), SceneTree.@SignalName
                                          .ProcessFrame );
            MapAreaPlaceHolder.RemoveChild(
            node           );
            node.QueueFree();
            MapAreaPlaceHolder.   AddChild(   mapArea   );
            MapAreaPlaceHolder.    NavigationMesh.Clear();
            MapAreaPlaceHolder.BakeNavigationMesh      ();
                             MainCharacter.GlobalPosition =
            mapArea.Entrances[entranceIdx].GlobalPosition ;
                             MainCharacter.ProcessMode    =
                                           ProcessModeEnum.
            Inherit;

            Environment.AmbientLightColor
                       =AmbientLightColors[(int)@nextMapArea];

            ScreenTransition
                       .Call              ("switch_map_area");

            DropManager
            dropManager=GetNode<
            DropManager        >
    ("/root/DropManager");
            dropManager.Save() ;
            dropManager.CurrentMapArea
                       =   nextMapArea;
            dropManager.Load() ;

            CurrentMapArea =
                   mapArea ;

            GetNode<SoundManagerBGMAmbient>  (
    $"/root/{nameof(SoundManagerBGMAmbient)}").CrossfadeTo(AmbientAudioStreams[(int)@nextMapArea]);

            if (MaterialApplying)
                   mapArea.MeshInstance3D.Mesh.SurfaceSetMaterial(
                                                      0, Material);
            }
        }
catch
{

}
    }

    public MapArea
    CurrentMapArea
    {
        get;
        set;
    }
    public void SwitchToMapAreaEntrance(int @entranceIdx)
    {
                           MainCharacter.GlobalPosition =
   CurrentMapArea.Entrances[entranceIdx].GlobalPosition ;
    }

    public void RegisterMonster(
                        Monster
                       @monster)
    {
                       @monster.NavigationRegion3DStatic = MapAreaPlaceHolder;
    }

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        ScreenTransition.Call("bleed" , ( MainCharacter.    MaxHealth
                                        - MainCharacter.CurrentHealth)
                                        / MainCharacter.    MaxHealth);
    }

    public           Aabb    BoundingBox
    {
    get => CurrentMapArea.GetBoundingBox();
    }

    [Export]
    public Material
           Material
    {
        get;
        set;
    }

    [Export]
    public bool
           MaterialApplying
    {
        get;
        set;
    }

    [Export]
    public Material
  SkyShaderMaterial
    {
        get;
        set;
    }

    [Export]
    public bool
  SkyShaderMaterialApplying
    {
        get;
        set;
    }
}




































