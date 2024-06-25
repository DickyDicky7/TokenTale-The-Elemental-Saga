using Godot ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
//     Abstract Command
public abstract partial class Command : Resource
{
public abstract void Initial(params object[] @objects);
public abstract void Execute(                        );
}


















