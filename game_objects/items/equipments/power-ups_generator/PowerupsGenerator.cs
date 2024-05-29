using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class PowerupsGenerator : Equipment
{
	public int MaxUses { get; private set; } = default;
	public PowerupsGenerator()
	{
		this.Available = false;
		this.Upgradeable = true;
		this.Level = -1;
		if (this.Available == true && this.Upgradeable == true)
			this.Upgrade();
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		Dictionary<int, Record.PowerUpsGeneratorInfo> PUGeneratoInfo
			= EquipmentStats.GetInstance().PowerUpsGeneratorStats;
		if (this.Level == PUGeneratoInfo.Count - 1)
			Upgradeable = false;
		this.MaxUses = PUGeneratoInfo[this.Level].MaxUses;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = PUGeneratoInfo[this.Level + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
	public void BeBought()
	{
		this.Available = true;
		Upgrade();
	}
}
