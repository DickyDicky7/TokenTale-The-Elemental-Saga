using Godot;
using Godot.Collections;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects      .Shared;

public partial class WeaponManager : Node
{
    [Export] public Array<Key> Keycodes { get; set; }
    [Export] public Array<BaseWeapon> Weapons { get; set; }
    [Export] public Array<Node2D> ParentNodes { get; set; }
    [Export] public Array<Vector2> DefaultPositions { get; set; }

    public void GetInput(InputEvent @inputEvent)
    {
        if (@inputEvent is InputEventKey inputEventKey)
        {
            int index = Keycodes.IndexOf(@inputEventKey.Keycode);
            if (inputEventKey.Pressed && index >= 0)
            {
                foreach (BaseWeapon weapon in Weapons)
                {
                    weapon.Hide();
                }
                Weapons[index].Show();
            }
        }
    }
}
