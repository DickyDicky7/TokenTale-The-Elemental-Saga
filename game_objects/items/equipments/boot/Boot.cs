using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Boot : Equipment
{
	public float Speed { get; private set; } = default;
	public int NextLevelUpgradeCost { get; private set; } = default;
	public Boot()
	{
		this.Available = true;
		this.Upgradeable = true;
		this.Level = 0;
		this.Speed = EquipmentStats.GetInstance().BootStats[this.Level].Speed;
		this.NextLevelUpgradeCost = EquipmentStats.GetInstance().BootStats[this.Level + 1].UpgradeCost;
	}
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		if (this.Level == EquipmentStats.GetInstance().BootStats.Count - 1)
			Upgradeable = false;
		this.Speed = EquipmentStats.GetInstance().BootStats[this.Level].Speed;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = EquipmentStats.GetInstance().BootStats[this.Level + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
	}
}
