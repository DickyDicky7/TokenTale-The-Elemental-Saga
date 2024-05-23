using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
namespace TokenTaleTheElementalSaga;

public partial class ElementalBracelet : Equipment
{
	public int Key { get; private set; } = default;
	public float BonusDamage { get; private set; } = default;
	public int NextLevelUpgradeCost { get; private set; } = default;
	public ElementalBracelet(bool Available, int Key)
	{
		this.Key = Key;
		this.Available = Available;
		this.Upgradeable = true;
		if (this.Available == true)
		{
			this.Level = 0;
			this.BonusDamage = EquipmentStats.GetInstance()
				.ElementalBraceletStats[this.Level]
				.BonusDamage;
			this.NextLevelUpgradeCost = EquipmentStats.GetInstance()
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
		if (this.Level == EquipmentStats.GetInstance().ElementalBraceletStats.Count - 1)
			this.Upgradeable = false;
		this.BonusDamage = EquipmentStats.GetInstance()
			.ElementalBraceletStats[this.Level]
			.BonusDamage;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = EquipmentStats.GetInstance()
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
