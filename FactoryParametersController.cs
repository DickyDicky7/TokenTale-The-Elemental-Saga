using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class FactoryParametersController : Node
{
    public override void _Ready()
    {
                    base._Ready();

        ProcessMode = ProcessModeEnum.Disabled;
    }
}
