using Godot;
using System;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
public partial class MainCharacterHUDController : Control
{
	[Export]
	public MainCharacter MainCharacter { get; set; }
	[Export]
	public TextureProgressBar HealthBar { get; set; }
	[Export]
	public PhysicsWeaponHUD SwordHUD { get; set; }
	[Export]
	public PhysicsWeaponHUD BowHUD { get; set; }
	public WeaponsController WeaponController { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.WeaponController = MainCharacter.WeaponsController;
		SetupHealthBar();
		SetupChosenWeapon();
		SetupCoolDownBar(SwordHUD.CoolDownBar, WeaponController.PhysicsWeapons[0].CoolDownTimer);
		SetupCoolDownBar(BowHUD.CoolDownBar, WeaponController.PhysicsWeapons[1].CoolDownTimer);
		SetupBowAmmo();
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
		UpdateCoolDownBar(SwordHUD.CoolDownBar, WeaponController.PhysicsWeapons[0].CoolDownTimer);
		UpdateCoolDownBar(BowHUD.CoolDownBar, WeaponController.PhysicsWeapons[1].CoolDownTimer);
	}
	private void OnHealthChanged(float damage)
	{
		if (damage > 0)
			this.HealthBar.Value = MainCharacter.CurrentHealth;
	}
	private void SetupHealthBar()
	{
		this.MainCharacter.HealthChange += OnHealthChanged;
		this.HealthBar.MaxValue = MainCharacter.MaxHealth;
		this.HealthBar.Value = MainCharacter.CurrentHealth;
	}
	private void OnPhysicsWeaponChanged(Weapon weapon)
	{
		if (weapon is Sword)
		{
			this.SwordHUD.WeaponIcon.EmitSignal(WeaponIcon.SignalName.PickedChange, true);
			this.BowHUD.WeaponIcon.EmitSignal(WeaponIcon.SignalName.PickedChange, false);
		}
		else
		{
			this.SwordHUD.WeaponIcon.EmitSignal(WeaponIcon.SignalName.PickedChange, false);
			this.BowHUD.WeaponIcon.EmitSignal(WeaponIcon.SignalName.PickedChange, true);
		}
	}
	private void SetupChosenWeapon()
	{
		this.WeaponController.ChosenPhysicsWeaponChanged += OnPhysicsWeaponChanged;
		OnPhysicsWeaponChanged(this.WeaponController.ChosenWeapon);
	}
	private void UpdateCoolDownBar(
		TextureProgressBar coolDownBar,
		Timer coolDownTimer)
	{
		if (coolDownTimer.IsStopped())
		{
			coolDownBar.Visible = false;
		}
		else
		{
			coolDownBar.Visible = true;
			coolDownBar.Value = coolDownTimer.TimeLeft * 100;
		}
	}
	private void SetupCoolDownBar(
		TextureProgressBar coolDownBar,
		Timer coolDownTimer)
	{
		coolDownBar.MaxValue = coolDownTimer.WaitTime * 100;
		UpdateCoolDownBar(coolDownBar, coolDownTimer);
	}
	private void OnBowShoot(int newCurrentArrow)
	{
		this.BowHUD.AmmoLabel.Text = newCurrentArrow.ToString();
	}
	private void OnBowOutOfAmmo()
	{
		AmmoLabel ammoLabel = this.BowHUD.AmmoLabel as AmmoLabel;
		ammoLabel.StartWarning();
	}
	private void SetupBowAmmo()
	{
		if (this.WeaponController.PhysicsWeapons[1] is not _Bow_)
			return;
		_Bow_ tempBow = this.WeaponController.PhysicsWeapons[1] as _Bow_;
		tempBow.Shoot += OnBowShoot;
		this.BowHUD.AmmoLabel.Text = tempBow.CurrentArrow.ToString();
		tempBow.OutOfArrow += OnBowOutOfAmmo;
	}
}
