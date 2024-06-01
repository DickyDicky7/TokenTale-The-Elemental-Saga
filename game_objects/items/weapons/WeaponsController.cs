using Godot;
using Godot.Collections;
using System.Linq;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class WeaponsController : Node
{
    [Export] public Array<Key> PhysicsWeaponKeys { get; set; }
    [Export] public Array<Weapon> PhysicsWeapons { get; set; }
    [Export] public Array<Key> BraceletKeys { get; set; }
    [Export] public Array<ElementalBracelet> Bracelets { get; set; }
    [Signal] 
    public delegate void ChosenPhysicsWeaponChangedEventHandler(Weapon @chosenWeapon);
    [Signal]
    public delegate void ChosenBraceletChangedEventHandler(ElementalBracelet elementalBracelet);

    public Weapon ChosenWeapon { get; protected  set; }
    public ElementalBracelet ChosenBracelet { get; protected set; }
    private Dictionary<Key, Weapon> WeaponControlDictionary { get; set; } = new();
    private Dictionary<Key, ElementalBracelet> BraceletControlDictionary { get; set; } = new();

    protected bool _lockSwitchingWeapons;
    protected bool _lockSwitchingBracelets;
    //ENSURE THE KEY AMOUNT == THE WEAPON AMOUNT!!!!!!!!!!!
    public override void _Ready()
    {
                    base._Ready();
		foreach (int i in Enumerable.Range(0, PhysicsWeapons.Count))
		{
			WeaponControlDictionary.Add(PhysicsWeaponKeys[i], PhysicsWeapons[i]);
            PhysicsWeapons[i].Disable();
		}
        ChosenWeapon = PhysicsWeapons[0];
        ChosenWeapon.IsInUseChanged += ChosenWeapon_IsInUseChanged;
        ChosenWeapon.En_able();
        foreach (int i in Enumerable.Range(0, Bracelets.Count))
        {
            BraceletControlDictionary.Add(BraceletKeys[i], Bracelets[i]);
            Bracelets[i].ProcessMode = ProcessModeEnum.Disabled;
        }
        ChosenBracelet = Bracelets[0];
        ChosenBracelet.IsInUseChanged += ChosenBraceletIsInUseChanged;
        ChosenBracelet.ProcessMode = ProcessModeEnum.Inherit;
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
                if (PhysicsWeaponKeys.Contains(inputEventKey.Keycode))
                {
                    SwitchPhysicsWeapon(inputEventKey);
                }
                if (BraceletKeys.Contains(inputEventKey.Keycode))
                {
                    SwitchBracelet(inputEventKey);
                }
            }
        }
    }
    private void SwitchPhysicsWeapon(InputEventKey inputEventKey)
    {
        Weapon potentialWeapon = null;
        potentialWeapon = WeaponControlDictionary[inputEventKey.Keycode];
        if (potentialWeapon != null
            && potentialWeapon != ChosenWeapon
            && potentialWeapon.Available == true)
        {
			ChosenWeapon.IsInUseChanged -= ChosenWeapon_IsInUseChanged;
			ChosenWeapon.Disable();
			potentialWeapon.IsInUseChanged += ChosenWeapon_IsInUseChanged;
			potentialWeapon.En_able();
			ChosenWeapon = potentialWeapon;
			EmitSignal(SignalName.ChosenPhysicsWeaponChanged, ChosenWeapon);
            ChosenWeapon.EmitSignal(Weapon.SignalName.Chosen, ChosenWeapon);
		}
    }
    private void SwitchBracelet(InputEventKey inputEventKey)
    {
        ElementalBracelet potentialBracelet = null;
		potentialBracelet = BraceletControlDictionary[inputEventKey.Keycode];
		if (potentialBracelet != null 
            && potentialBracelet != ChosenBracelet
            && potentialBracelet.Available == true)
		{
			ChosenBracelet.IsInUseChanged -= ChosenBraceletIsInUseChanged;
			ChosenBracelet.Disable();
			potentialBracelet.IsInUseChanged += ChosenBraceletIsInUseChanged;
			potentialBracelet.En_able();
			ChosenBracelet = potentialBracelet;
			EmitSignal(SignalName.ChosenBraceletChanged, ChosenBracelet);
            ChosenBracelet.EmitSignal(Weapon.SignalName.Chosen, ChosenBracelet);
		}
	}

    private void ChosenWeapon_IsInUseChanged(bool @isInUse)
    {
        _lockSwitchingWeapons = @isInUse;
    }
    private void ChosenBraceletIsInUseChanged(bool @isInUse)
    {
        _lockSwitchingBracelets = @isInUse;
    }
}
