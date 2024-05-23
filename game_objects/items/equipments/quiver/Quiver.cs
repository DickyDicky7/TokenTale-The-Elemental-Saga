using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Quiver : Equipment
{
	public int MaxArrow { get; private set; } = default;
	public int NextLevelUpgradeCost { get; private set; } = default;
	public Quiver()
	{
		this.Available = true;
		this.Upgradeable = true;
		this.Level = 0;
		this.MaxArrow = EquipmentStats.GetInstance()
			.QuiverStats[this.Level]
			.MaxArrow;
		this.NextLevelUpgradeCost = EquipmentStats.GetInstance()
			.QuiverStats[this.Level + 1]
			.UpgradeCost;
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		if (this.Level == EquipmentStats.GetInstance().QuiverStats.Count - 1)
			Upgradeable = false;
		this.MaxArrow = EquipmentStats.GetInstance()
			.QuiverStats[this.Level]
			.MaxArrow;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = EquipmentStats.GetInstance()
				.QuiverStats[this.Level + 1]
				.UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
}
