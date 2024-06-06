using Godot;
using Godot.Collections;
using System;
namespace TokenTaleTheElementalSaga;
public partial class TrackWeapon : PanelContainer
{
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
	[Export]
	public PackedScene Trackerv2PackedScene { get; set; }
	[Export]
	public VBoxContainer TrackerContainer { get; set; }
	private WeaponsController WeaponsController { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.WeaponsController = this.TrackingScreen.Viewer.WeaponsController;
		this.SetupAllTracker();
	}
	private void SetupAllTracker()
	{
		WeaponStats weaponStats = WeaponStats.GetInstance();
		this.SetupWeaponTrackers(weaponStats);
		this.SetupBraceletTrackers(weaponStats);
	}
	private void SetupWeaponTrackers(WeaponStats weaponStats)
	{
		foreach(Weapon weapon in WeaponsController.PhysicsWeapons)
		{
			if (weapon is Sword sword)
			{
				int totalLevel = weaponStats.SwordStats.Count;
				Trackerv2 temp = SetupSwordTracker(totalLevel, sword);
				this.TrackerContainer.AddChild(temp);
			}
			if (weapon is _Bow_ bow)
			{
				int totalLevel = weaponStats.BowStats.Count;
				Trackerv2 temp = SetupBowTracker(totalLevel, bow);
				this.TrackerContainer.AddChild(temp);
			}
		}
	}
	private void SetupBraceletTrackers(WeaponStats weaponStats)
	{
		foreach(ElementalBracelet bracelet in WeaponsController.Bracelets)
		{
			int totalLevel = weaponStats.ElementalBraceletStats.Count;
			Trackerv2 temp = SetupBraceletTracker(totalLevel, bracelet);
			this.TrackerContainer.AddChild(temp);
		}
	}
	private Trackerv2 SetupSwordTracker(int totalLevel, Sword sword)
	{
		Trackerv2 temp = this.Trackerv2PackedScene.Instantiate<Trackerv2>();
		temp.Setup(
			"SWORD",
			$"Damage: {sword.Damage}",
			totalLevel,
			sword);
		return temp;
	}
	private Trackerv2 SetupBowTracker(int totalLevel, _Bow_ bow)
	{
		Trackerv2 temp = this.Trackerv2PackedScene.Instantiate<Trackerv2>();
		temp.Setup(
			"BOW",
			$"Damage: {bow.Damage}",
			totalLevel,
			bow);
		return temp;
	}
	private Trackerv2 SetupBraceletTracker(int totalLevel, ElementalBracelet bracelet)
	{
		Trackerv2 temp = this.Trackerv2PackedScene.Instantiate<Trackerv2>();
		temp.Setup(
			"ELEMENTAL BRACELET",
			$"Bonus damage: {bracelet.BonusDamage}",
			totalLevel,
			bracelet);
		return temp;
	}
}
