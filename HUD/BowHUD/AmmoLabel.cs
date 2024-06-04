using Godot;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class AmmoLabel : Label
{
	private Timer WarningTimer { get; set; } = new();
	private Color WarningColor = Helper.Color255ToColor1(204, 51, 0, 255);
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
		this.SelfModulate = this.WarningColor;
		WarningTimer.Start();
	}
	public void EndWarning()
	{
		this.SelfModulate = new Color(1, 1, 1, 1);
		WarningTimer.Stop();
	}
}
