using Godot;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class AmmoLabel : Label
{
	private Timer WarningTimer { get; set; } = new();
	public override void _Ready()
	{
		base._Ready();
		WarningTimer.OneShot = true;
		WarningTimer.WaitTime = 0.5d;
		WarningTimer.ProcessCallback = Timer.TimerProcessCallback.Physics;
		WarningTimer.ProcessMode = ProcessModeEnum.Always;
		WarningTimer.Timeout += EndWarning;
		this.AddChild(WarningTimer);
	}
	public void StartWarning()
	{
		WarningTimer.Stop();
		this.SelfModulate = new Color(204, 51, 0);
		WarningTimer.Start();
	}
	public void EndWarning()
	{
		this.SelfModulate = new Color(255, 255, 255);
		WarningTimer.Stop();
	}
}
