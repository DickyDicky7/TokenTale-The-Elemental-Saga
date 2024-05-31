using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class PhysicsWeaponHUD : Control
{
	[Export]
	public TextureProgressBar CoolDownBar { get; set; }
	[Export]
	public WeaponIcon WeaponIcon { get; set; }
	[Export]
	public Label AmmoLabel { get; set; }
	public void UpdateCoolDownBar(bool isTimerStopped, double value)
	{
		if (isTimerStopped)
		{
			this.CoolDownBar.Visible = false;
		}
		else
		{
			this.CoolDownBar.Visible = true;
			this.CoolDownBar.Value = value;
		}
	}
}
