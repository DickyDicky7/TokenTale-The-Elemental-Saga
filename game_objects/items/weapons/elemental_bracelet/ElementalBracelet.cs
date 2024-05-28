using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class ElementalBracelet : Weapon
{
	[Export]
	public MainCharacter OwnerMainCharacter { get; set; }
	[Export]
	public Global.Element CurrentElement { get; set; } = Global.Element.None;
	public float BonusDamage { get; private set; } = default;
	public int NextLevelUpgradeCost { get; private set; } = default;
	public ElementalBracelet()
	{
		this.Upgradeable = true;
		if (this.Available == true)
		{
			this.Level = 0;
			this.BonusDamage = WeaponStats.GetInstance()
				.ElementalBraceletStats[this.Level]
				.BonusDamage;
			this.NextLevelUpgradeCost = WeaponStats.GetInstance()
				.ElementalBraceletStats[this.Level + 1]
				.UpgradeCost;
		}
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		if (this.Level == WeaponStats.GetInstance().ElementalBraceletStats.Count - 1)
			this.Upgradeable = false;
		this.BonusDamage = WeaponStats.GetInstance()
			.ElementalBraceletStats[this.Level]
			.BonusDamage;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = WeaponStats.GetInstance()
				.ElementalBraceletStats[this.Level + 1]
				.UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
	public void BeTaken()
	{
		this.Available = true;
		Upgrade();
	}
}
