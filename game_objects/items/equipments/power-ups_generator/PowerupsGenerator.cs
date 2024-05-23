using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class PowerupsGenerator : Equipment
{
	public int MaxUses { get; private set; } = default;
	public int NextLevelUpgradeCost { get; private set; } = default;
	public PowerupsGenerator()
	{
		this.Available = false;
		this.Upgradeable = true;
		this.Level = -1;
		this.MaxUses = 0;
		this.NextLevelUpgradeCost = EquipmentStats.GetInstance()
			.PowerUpsGeneratorStats[0]
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
		if (this.Level == EquipmentStats.GetInstance().PowerUpsGeneratorStats.Count - 1)
			Upgradeable = false;
		this.MaxUses = EquipmentStats.GetInstance()
			.PowerUpsGeneratorStats[this.Level]
			.MaxUses;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = EquipmentStats.GetInstance()
				.PowerUpsGeneratorStats[this.Level + 1]
				.UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;

	}
	public void BeBought()
	{
		this.Available = true;
		Upgrade();
	}
}
