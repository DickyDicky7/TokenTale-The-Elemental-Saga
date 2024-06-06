using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class TrackerHealthJar : Control
{
	[Export]
	public TextureProgressBar ProgressBar { get; set; }

	public void Update(HealthJar healthJar)
	{
		this.ProgressBar.Value = healthJar.CurrentValue;
		this.ProgressBar.MaxValue = healthJar.MaxValue;
	}
}
