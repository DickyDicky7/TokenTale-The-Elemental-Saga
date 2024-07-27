using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class CommandSpawnMonster : Command
{
    public MapSystem
           MapSystem
    {
        get;
        set;
    } // Receiver of Command

    public VisibleOnScreenNotifier3D
           SpawnArea
    {
        get;
        set;
    }

    [Export]
    public StrategySpawnMonster
           StrategySpawnMonster
    {
        get;
        set;
    }

    public override void Execute(                        )
    {
    StrategySpawnMonster.Execute(MapSystem
                                ,         SpawnArea);
    }

    public override void Initial(params object[] @objects)
    {
           MapSystem =                           @objects
[0] as     MapSystem ;

           SpawnArea =                           @objects
[2] as                          VisibleOnScreenNotifier3D;
    }
}





