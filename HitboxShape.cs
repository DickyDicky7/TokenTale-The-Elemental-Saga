using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HitboxShape : Resource
{
    [Export()]
    public Shape2D Shape { get; set; }
}
