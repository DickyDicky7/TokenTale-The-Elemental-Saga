using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Weapon : Equipment
{
	[Export]
	public MainCharacter OwnerMainCharacter { get; set; }
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
    public Timer CoolDownTimer { get; protected set; } = new();
    public bool IsCoolingDown { get; set; } = false;
    [Signal]
    public delegate void IsInUseChangedEventHandler
                                            (bool @isInUse);
    [Signal]
    public delegate void ChosenEventHandler(Weapon chosenWeapon);

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
	public override void _Ready()
	{
		base._Ready();
        TimerSetup();
	}
	public void TimerSetup()
    {
        this.CoolDownTimer.OneShot = true;
        this.CoolDownTimer.WaitTime = 1.0d;
        this.CoolDownTimer.ProcessCallback = Timer.TimerProcessCallback.Physics;
        this.CoolDownTimer.Timeout += EndCoolDown;
        this.CoolDownTimer.ProcessMode = ProcessModeEnum.Always;
        this.AddChild(CoolDownTimer);
    }
    public void StartCoolDown()
    {
        this.CoolDownTimer.Start();
        this.IsCoolingDown = true;
    }
    public void EndCoolDown()
    {
        this.CoolDownTimer.Stop();
        this.IsCoolingDown = false;
    }
}
