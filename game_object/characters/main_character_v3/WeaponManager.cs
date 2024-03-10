using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public partial class WeaponManager : Node
{
    [Export] public Array<Key   > Keys    { get; set; }
    [Export] public Array<Weapon> Weapons { get; set; }
    [Signal] public delegate void ChosenWeaponChangedEventHandler(Weapon @chosenWeapon);

    public Weapon ChosenWeapon { get; protected  set; }

    public override void _Ready()
    {
                    base._Ready();
        foreach (Weapon weapon in Weapons)
        {
              weapon.ProcessMode = ProcessModeEnum.Disabled;
              weapon.Hide();
        }
        ChosenWeapon = Weapons[0];
        ChosenWeapon.ProcessMode = ProcessModeEnum.
             Inherit;
        ChosenWeapon.Show();
    }

    public override void _Input(InputEvent @inputEvent)
    {
                    base._Input(           @inputEvent);
        if (@inputEvent is
             InputEventKey
             inputEventKey)
        {
            if (inputEventKey.Pressed)
            {
                Weapon chosenWeapon = null;
                int index  = Keys.IndexOf(inputEventKey.Keycode);
                if (index != -1)
                {
                       chosenWeapon = Weapons[index];
                }

                if (chosenWeapon != null
                &&  chosenWeapon != ChosenWeapon)
                {
                    ChosenWeapon.ProcessMode = ProcessModeEnum.Disabled;
                    ChosenWeapon.Hide();
                    chosenWeapon.ProcessMode = ProcessModeEnum.
                         Inherit;
                    chosenWeapon.Show();
                    ChosenWeapon  = chosenWeapon;
                    EmitSignal(SignalName.ChosenWeaponChanged);
                }
            }
        }
    }
}
