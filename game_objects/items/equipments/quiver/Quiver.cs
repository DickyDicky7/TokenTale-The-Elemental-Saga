using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Quiver : Equipment
{
	public int MaxArrow { get; private set; } = default;
	public Quiver(MainCharacter mainCharacter)
	{
		this.Available = true;
		this.Upgradeable = true;
		this.Level = -1;
		if (this.Available == true && this.Upgradeable == true)
			this.Upgrade();
		this.OwnerMainCharacter = mainCharacter;
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		Dictionary<int, Record.QuiverInfo> QuiverStats
			= EquipmentStats.GetInstance().QuiverStats;
		if (this.Level == QuiverStats.Count - 1)
			Upgradeable = false;
		this.MaxArrow = QuiverStats[this.Level].MaxArrow;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = QuiverStats[this.Level + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
		this.EmitSignal(Equipment.SignalName.JustUpgrade);
	}
}
