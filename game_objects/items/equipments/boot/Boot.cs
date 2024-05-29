using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Boot : Equipment
{
	public float Speed { get; private set; } = default;
	public Boot()
	{
		this.Available = true;
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
		Dictionary<int, Record.BootInfo> BootStats
			= EquipmentStats.GetInstance().BootStats;
		if (this.Level == BootStats.Count - 1)
			Upgradeable = false;
		this.Speed = BootStats[this.Level].Speed;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = BootStats[this.Level + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
}
