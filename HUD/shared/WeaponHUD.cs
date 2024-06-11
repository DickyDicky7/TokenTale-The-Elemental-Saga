using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class WeaponHUD : Control
{
	[Export]
	public TextureProgressBar CoolDownBar { get; set; }
	[Export]
	public WeaponIcon WeaponIcon { get; set; }
	public Weapon Partner { get; set; }
	[Signal]
	public delegate void PartnerChosenEventHandler(Weapon weapon);
	public override void _Process(double delta)
	{
		base._Process(delta);
		UpdateCoolDownBar();
	}
	public virtual void Setup(Weapon chosenWeapon)
	{
		SetupCoolDownBar();
		SetupIcon(chosenWeapon);
		if (this.Partner.Available is false)
		{
			this.Visible = false;
		}
		this.Partner.Taken += OnPartnerTaken;
	}
	private void OnPartnerTaken()
	{
		this.Visible = true;
	}
	//CoolDownBar method group
	private void SetupCoolDownBar()
	{
		this.CoolDownBar.MaxValue = Partner.CoolDownTimer.WaitTime * 100;
	}
	private void UpdateCoolDownBar()
	{
		Timer coolDownTimer = Partner.CoolDownTimer;
		if (coolDownTimer.IsStopped())
		{
			this.CoolDownBar.Visible = false;
		}
		else
		{
			this.CoolDownBar.Visible = true;
			this.CoolDownBar.Value = coolDownTimer.TimeLeft * 100;
		}
	}
	//Icon method group
	private void SetupIcon(Weapon chosenWeapon)
	{
		Partner.Chosen += OnWeaponChosen;
		if (Partner == chosenWeapon)
			this.WeaponIcon.IconFrame.EmitSignal(IconFrame.SignalName.ChosenChanged, true);
	}
	private void OnWeaponChosen(Weapon chosenWeapon)
	{
		this.WeaponIcon.IconFrame.EmitSignal(IconFrame.SignalName.ChosenChanged, true);
		this.EmitSignal(WeaponHUD.SignalName.PartnerChosen, chosenWeapon);
	}
	public void OnOtherWeaponChosen()
	{
		this.WeaponIcon.IconFrame.EmitSignal(IconFrame.SignalName.ChosenChanged, false);
	}
}
