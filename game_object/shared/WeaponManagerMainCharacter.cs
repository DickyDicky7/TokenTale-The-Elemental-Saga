using Godot;
using Godot.Collections;

using     TokenTaleTheElementalSaga.GameObjects.Characters;
using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects      .Shared;

public partial class WeaponManagerMainCharacter : BaseWeaponManager
{
    private int _currIndex = -1;
    private int _lastIndex = -1;

    [Export] public Array<Key> CorrespondingKeycodes { get; set; }
    [Export] public Array<Node2D > CorrespondingOldParentNodes { get; set; }
    [Export] public Array<Node2D > CorrespondingNewParentNodes { get; set; }
    [Export] public Array<Vector2> CorrespondingOldPositions   { get; set; }
    [Export] public Array<Vector2> CorrespondingNewPositions   { get; set; }

    public override void _Ready()
    {
        if (Weapons.Count > 0)
        {
            HideWeapons();
            ShowTWeapon(Weapons[0]);
            Weapons[0].OnWieldCease += OnCurrentWeaponWieldCease;
            _currIndex = 0;
            _lastIndex = 0;
        }
    }

    public void HandleInputSwitchCurrentWeapon(InputEvent @inputEvent)
    {
        if (@inputEvent is InputEventKey inputEventKey)
        {
            if (inputEventKey.Pressed && CorrespondingKeycodes.IndexOf(@inputEventKey.Keycode) >= 0)
            {
                _currIndex =             CorrespondingKeycodes.IndexOf(@inputEventKey.Keycode);
                HideWeapons();
                ShowTWeapon(Weapons[_currIndex]);
                if (_lastIndex >= 0
                &&  _lastIndex <  Weapons.Count)
                {
                Weapons[_lastIndex].OnWieldCease -= OnCurrentWeaponWieldCease;
                }
                Weapons[_currIndex].OnWieldCease += OnCurrentWeaponWieldCease;
                _lastIndex = _currIndex;
            }
        }
    }

    private void OnCurrentWeaponWieldCease()
    {
        EmitSignal(SignalName.OnWieldCurrentWeaponCease);
    }

    public override void WieldCurrentWeapon()
    {
        if (_currIndex >= 0)
        {
            Weapons[_currIndex].Reparent ( CorrespondingNewParentNodes[_currIndex], keepGlobalTransform: false);
            Weapons[_currIndex].Position = CorrespondingNewPositions  [_currIndex];
            Weapons[_currIndex].Wield();
        }
    }

    public override void ResetCurrentWeapon()
    {
        if (_currIndex >= 0)
        {
            Weapons[_currIndex].Reset();
            Weapons[_currIndex].Reparent ( CorrespondingOldParentNodes[_currIndex], keepGlobalTransform: false);
            Weapons[_currIndex].Position = CorrespondingOldPositions  [_currIndex];
        }
    }
}
