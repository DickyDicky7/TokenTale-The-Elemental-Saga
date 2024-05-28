using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Weapon : Equipment
{
    protected      bool _isInUse     ;
    public virtual bool  IsInUse
    {
        get => _isInUse;
        set
        {
               _isInUse = value;
            EmitSignal(SignalName.IsInUseChanged, _isInUse);
        }
    }
    [Signal]
    public delegate void IsInUseChangedEventHandler
                                            (bool @isInUse);

    public void Disable()
    {
        ProcessMode = ProcessModeEnum.Disabled;
        Hide();
    }

    public void En_able()
    {
        ProcessMode = ProcessModeEnum.
            Inherit;
        Show();
    }
}
