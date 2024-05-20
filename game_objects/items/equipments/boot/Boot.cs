using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Boot : Equipment
{
	public float Speed { get; private set; }
	public int NextLevelUpgradeCost { get; private set; }
	public Boot()
	{
		this.Available = true;
		this.Upgradeable = true;
		this.Level = 0;
		this.Speed = ItemStats.BootStats[0].Speed;
		this.NextLevelUpgradeCost = ItemStats.BootStats[1].UpgradeCost;
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
			.BootStats
			.FindIndex(0, ItemStats.BootStats.Count, x => x.Level == this.Level);
		this.Speed = ItemStats.BootStats[index].Speed;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = ItemStats.BootStats[index + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
}
