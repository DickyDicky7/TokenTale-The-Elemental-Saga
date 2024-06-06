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
				TrackerContainerEquipment temp = SetupSwordTracker(totalLevel, sword);
				this.TrackerContainer.AddChild(temp);
			}
			if (weapon is _Bow_ bow)
			{
				int totalLevel = weaponStats.BowStats.Count;
				TrackerContainerEquipment temp = SetupBowTracker(totalLevel, bow);
				this.TrackerContainer.AddChild(temp);
			}
		}
	}
	private void SetupBraceletTrackers(WeaponStats weaponStats)
	{
		foreach(ElementalBracelet bracelet in WeaponsController.Bracelets)
		{
			int totalLevel = weaponStats.ElementalBraceletStats.Count;
			TrackerContainerEquipment temp = SetupBraceletTracker(totalLevel, bracelet);
			this.TrackerContainer.AddChild(temp);
		}
	}
	private TrackerContainerEquipment SetupSwordTracker(int totalLevel, Sword sword)
	{
		TrackerContainerEquipment temp = this.Trackerv2PackedScene.Instantiate<TrackerContainerEquipment>();
		temp.Setup(
			"SWORD",
			$"Damage: {sword.Damage}",
			totalLevel,
			sword);
		return temp;
	}
	private TrackerContainerEquipment SetupBowTracker(int totalLevel, _Bow_ bow)
	{
		TrackerContainerEquipment temp = this.Trackerv2PackedScene.Instantiate<TrackerContainerEquipment>();
		temp.Setup(
			"BOW",
			$"Damage: {bow.Damage}",
			totalLevel,
			bow);
		return temp;
	}
	private TrackerContainerEquipment SetupBraceletTracker(int totalLevel, ElementalBracelet bracelet)
	{
		TrackerContainerEquipment temp = this.Trackerv2PackedScene.Instantiate<TrackerContainerEquipment>();
		temp.Setup(
			"ELEMENTAL BRACELET",
			$"Bonus damage: {bracelet.BonusDamage}",
			totalLevel,
			bracelet);
		return temp;
	}
}
