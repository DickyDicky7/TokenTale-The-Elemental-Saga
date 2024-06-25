using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class StrategySpawnMonster : Resource
{
public abstract void Execute( MapSystem 
                             @mapSystem                  ,
                              VisibleOnScreenNotifier3D
                             @spawnArea                 );
}







