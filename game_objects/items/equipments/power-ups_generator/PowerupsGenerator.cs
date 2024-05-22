using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class PowerupsGenerator : Equipment
{
	public int MaxUses { get; private set; }
	public int NextLevelUpgradeCost { get; private set; }
	public PowerupsGenerator()
	{
		this.Available = false;
		this.Upgradeable = true;
		this.Level = -1;
		this.MaxUses = 0;
		this.NextLevelUpgradeCost = ItemStats.GetInstance().PowerUpsGeneratorStats[0].UpgradeCost;
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		if (this.Level == ItemStats.GetInstance().PowerUpsGeneratorStats.Count - 1)
			Upgradeable = false;
		int index = ItemStats.GetInstance()
			.PowerUpsGeneratorStats
			.FindIndex(0, ItemStats.GetInstance().PowerUpsGeneratorStats.Count, x => x.Level == this.Level);
		this.MaxUses = ItemStats.GetInstance().PowerUpsGeneratorStats[index].MaxUses;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = ItemStats.GetInstance().PowerUpsGeneratorStats[index + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;

	}
	public void BeBought()
	{
		this.Available = true;
		Upgrade();
	}
}