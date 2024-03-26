using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MovingSpeed : Resource
{
    [Export()]
    public float Value { get; set; }
}
