using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class RadiusRange : Resource
{
    [Export()]
    public float Min { get; set; }
    [Export()]
    public float Max { get; set; }
}

