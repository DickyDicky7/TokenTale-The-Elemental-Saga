using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Ghost : Monster
{
    public override void Attack(Character3D target)
    {
        this.QueueFree();
    }
}
