using Godot;
using TokenTaleTheElementalSaga.GameObjects.Items.Wood;

namespace TokenTaleTheElementalSaga;

public partial class Main : Node
{
    public override void _Ready()
    {
        GetNode<Timer>(nameof(Timer)).Timeout += () =>
        {
            Quiver quiver  = GetNode<Quiver>(nameof(Quiver));
            quiver.IsEmpty = true;
        };
    }
}
