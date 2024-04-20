using Godot;

namespace TokenTaleTheElementalSaga;

[Tool]
[GlobalClass]
public abstract partial class GenerationStrategy : Resource
{
public abstract void Generate(Node3D @generationSpace);
}
