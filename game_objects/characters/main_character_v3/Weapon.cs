using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public abstract partial class Weapon : Item
{
    private bool _isInUse;
    [Signal]
    public delegate void IsInUseChangedEventHandler(bool @isInUse);
}
