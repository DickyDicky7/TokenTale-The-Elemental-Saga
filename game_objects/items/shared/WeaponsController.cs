using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class WeaponsController : Node
{
    [Export] public Array<Key   > Keys    { get; set; }
    [Export] public Array<Weapon> Weapons { get; set; }
    [Signal] public delegate void ChosenWeaponChangedEventHandler(Weapon @chosenWeapon);

    public Weapon ChosenWeapon { get; protected  set; }

    protected bool _lockSwitching;

    public override void _Ready()
    {
                    base._Ready();

        foreach (Weapon weapon in Weapons)
        {
              weapon.Disable();
        }
        ChosenWeapon =            Weapons[0];
        ChosenWeapon.IsInUseChanged +=
        ChosenWeapon_IsInUseChanged         ;
        ChosenWeapon.En_able();
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
                    ChosenWeapon.IsInUseChanged -= ChosenWeapon_IsInUseChanged;
                    ChosenWeapon.Disable();
                    chosenWeapon.IsInUseChanged += ChosenWeapon_IsInUseChanged;
                    chosenWeapon.En_able();
                    ChosenWeapon  = chosenWeapon;
                    EmitSignal(SignalName.ChosenWeaponChanged, ChosenWeapon);
                }
            }
        }
    }

    private void ChosenWeapon_IsInUseChanged(bool @isInUse)
    {
        _lockSwitching = @isInUse;
    }
}
