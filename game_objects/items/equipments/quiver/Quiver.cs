using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Quiver : Equipment
{
	public int MaxArrow { get; private set; }
	public int NextLevelUpgradeCost { get; private set; }
	public Quiver()
	{
		this.Available = true;
		this.Upgradeable = true;
		this.Level = 0;
		this.MaxArrow = ItemStats.QuiverStats[0].MaxArrow;
		this.NextLevelUpgradeCost = ItemStats.QuiverStats[1].UpgradeCost;
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		if (this.Level == ItemStats.QuiverStats.Count - 1)
			Upgradeable = false;
		int index = ItemStats
			.QuiverStats
			.FindIndex(0, ItemStats.QuiverStats.Count, x => x.Level == this.Level);
		this.MaxArrow = ItemStats.QuiverStats[index].MaxArrow;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = ItemStats.QuiverStats[index + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
}
