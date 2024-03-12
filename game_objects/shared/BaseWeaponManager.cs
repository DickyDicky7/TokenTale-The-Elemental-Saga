using Godot;
using Godot.Collections;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects      .Shared;

public abstract partial class BaseWeaponManager : Node
{
    [Export] public Array<BaseWeapon> Weapons { get; set; }

    [Signal] public delegate void OnWieldCurrentWeaponStartEventHandler();
    [Signal] public delegate void OnWieldCurrentWeaponCeaseEventHandler();

    public abstract void WieldCurrentWeapon();
    public abstract void ResetCurrentWeapon();

    protected void HideWeapons()
    {
        foreach               (BaseWeapon weapon in Weapons)
        {
            weapon.Hide();
            weapon.CollisionShape2DHitbox.SetDeferred("disabled", true);
        }
    }

    protected void ShowTWeapon(BaseWeapon weapon)
    {
            weapon.Show();
            weapon.CollisionShape2DHitbox.SetDeferred("disabled", true);
    }
}
