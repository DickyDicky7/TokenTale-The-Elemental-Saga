using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StrategySpawnMonsterDefault
                   : StrategySpawnMonster
{
    [Export]
    public Array< PackedScene >
           MonsterPackedScenes
    {
        get;
        set;
    } = [ ];

    [Export]
    public int Threshold { get; set; }
    public int Count     { get; set; }

    public override void Execute(MapSystem @mapSystem , VisibleOnScreenNotifier3D @spawnArea)
    {
        if (Count >= Threshold)
            return    ;

            Count += 1;

        Monster
        monster                          =
        MonsterPackedScenes[GD.RandRange(  0
,       MonsterPackedScenes   .    Count - 1  )].Instantiate<Monster>();

        @mapSystem.RegisterMonster(
        monster                   );
        monster        .Position =
        @spawnArea.Aabb.Position + new Vector3
        (
            x: (float)GD.RandRange(0.0d, @spawnArea.Aabb.Size.X),
            y: (float)GD.RandRange(0.0d, @spawnArea.Aabb.Size.Y),
            z: (float)GD.RandRange(0.0d, @spawnArea.Aabb.Size.Z)
        );
        @spawnArea.AddChild       (
        monster                   );
    }
}



