using Godot;

namespace TokenTaleTheElementalSaga;

[Tool]
public partial class TornadoMultiMeshInstance3D : MultiMeshInstance3D
{
    public override void _Ready()
    {
                    base._Ready();
        for (int index = 0;
                 index < Multimesh.InstanceCount;
               ++index)
        {
            Multimesh.SetInstanceTransform(index, new(Basis.Identity, new()));
        }
    }
}

