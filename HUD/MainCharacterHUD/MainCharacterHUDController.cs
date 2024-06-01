using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
public partial class MainCharacterHUDController : Control
{
	[Export]
	public MainCharacter MainCharacter { get; set; }
	[Export]
	public TextureProgressBar HealthBar { get; set; }
	[Export]
	public WeaponHUD SwordHUD { get; set; }
	[Export]
	public BowHUD BowHUD { get; set; }
	[Export]
	public Array<ElementalBraceletHUD> BraceletHUDs { get; set; }
	public WeaponsController WeaponController { get; set; }
	private List<WeaponHUD> WeaponHUDs { get; set; } = new();
	public override void _Ready()
	{
		base._Ready();
		this.WeaponController = MainCharacter.WeaponsController;
		SetupHealthBar();
		SetupBraceletHUD();
		SetupWeaponHUD();
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
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
	private void SetupWeaponHUD()
	{
		this.SwordHUD.Partner = this.WeaponController.PhysicsWeapons[0];
		this.BowHUD.Partner = this.WeaponController.PhysicsWeapons[1];
		this.WeaponHUDs.Add(SwordHUD);
		this.WeaponHUDs.Add(BowHUD);
		foreach(WeaponHUD weaponHUD in WeaponHUDs)
		{
			weaponHUD.Setup(WeaponController.ChosenWeapon);
			weaponHUD.PartnerChosen += OnNewChosenWeapon;
		}
	}
	private void OnNewChosenWeapon(Weapon weapon)
	{
		foreach (WeaponHUD weaponHUD in WeaponHUDs)
		{
			if (weaponHUD.Partner == weapon)
				continue;
			weaponHUD.OnOtherWeaponChosen();
		}
	}
	private void SetupBraceletHUD()
	{
		for (int i = 0; i < BraceletHUDs.Count; i++)
		{
			BraceletHUDs[i].Partner = WeaponController.Bracelets[i];
			BraceletHUDs[i].Setup(
				MainCharacter.BoosterManager.MaxEnergy,
				WeaponController.ChosenBracelet);
			BraceletHUDs[i].PartnerChosen += OnNewChosenBracelet;
		}
	}
	private void OnNewChosenBracelet(Weapon weapon)
	{
		foreach (ElementalBraceletHUD braceletHUD in BraceletHUDs)
		{
			if (braceletHUD.Partner == weapon)
				continue;
			braceletHUD.OnOtherWeaponChosen();
		}
	}
}
