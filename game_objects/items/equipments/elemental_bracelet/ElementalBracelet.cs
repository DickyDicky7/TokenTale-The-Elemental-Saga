using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
namespace TokenTaleTheElementalSaga;

public partial class ElementalBracelet : Equipment
{
	public int Key { get; private set; }
	public float BonusDamage { get; private set; }
	public int NextLevelUpgradeCost { get; private set; }
	public ElementalBracelet(bool Available, int Key)
	{
		this.Key = Key;
		this.Available = Available;
		this.Upgradeable = true;
		this.Level = this.Available == true ? 0 : 1;
		if (Level < 0)
			this.BonusDamage = 0;
		else
			this.BonusDamage = ItemStats.GetInstance().ElementalBraceletStats[0].BonusDamage;
		this.NextLevelUpgradeCost = ItemStats.GetInstance().ElementalBraceletStats[1].UpgradeCost;
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		if (this.Level == ItemStats.GetInstance().ElementalBraceletStats.Count - 1)
			this.Upgradeable = false;
		int index = ItemStats.GetInstance()
			.ElementalBraceletStats
			.FindIndex(0, ItemStats.GetInstance().ElementalBraceletStats.Count, x => x.Level == this.Level);
		this.BonusDamage = ItemStats.GetInstance().ElementalBraceletStats[index].BonusDamage;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = ItemStats.GetInstance().ElementalBraceletStats[index + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
	public void BeTaken()
	{
		this.Available = true;
		Upgrade();
	}
}
