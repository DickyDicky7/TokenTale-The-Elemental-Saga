using Godot;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class EquipmentStats : Resource
{
	private static EquipmentStats _instance;
	public static EquipmentStats GetInstance()
	{
		if (_instance == null)
			_instance = new EquipmentStats();
		return _instance;
	}
	private EquipmentStats() : base()
	{
		SwordStats.Add(0, new Record.SwordInfo { Damage = 10, UpgradeCost = 0 });
		SwordStats.Add(1, new Record.SwordInfo { Damage = 13, UpgradeCost = 100 });
		SwordStats.Add(2, new Record.SwordInfo { Damage = 16, UpgradeCost = 150 });
		SwordStats.Add(3, new Record.SwordInfo { Damage = 19, UpgradeCost = 200 });
		SwordStats.Add(4, new Record.SwordInfo { Damage = 22, UpgradeCost = 250 });

		BowStats.Add(0, new Record.BowInfo { Damage = 10, UpgradeCost = 0 });
		BowStats.Add(1, new Record.BowInfo { Damage = 14, UpgradeCost = 100 });
		BowStats.Add(2, new Record.BowInfo { Damage = 18, UpgradeCost = 175 });
		BowStats.Add(3, new Record.BowInfo { Damage = 22, UpgradeCost = 250 });
		BowStats.Add(4, new Record.BowInfo { Damage = 26, UpgradeCost = 325 });

		QuiverStats.Add(0, new Record.QuiverInfo { MaxArrow = 15, UpgradeCost = 0 });
		QuiverStats.Add(1, new Record.QuiverInfo { MaxArrow = 30, UpgradeCost = 50 });
		QuiverStats.Add(2, new Record.QuiverInfo { MaxArrow = 45, UpgradeCost = 90 });
		QuiverStats.Add(3, new Record.QuiverInfo { MaxArrow = 60, UpgradeCost = 140 });
		QuiverStats.Add(4, new Record.QuiverInfo { MaxArrow = 75, UpgradeCost = 200 });

		ElementalBraceletStats.Add(0, new Record.ElementalBraceletInfo 
		{ BonusDamage = 0, UpgradeCost = 0 });
		ElementalBraceletStats.Add(1, new Record.ElementalBraceletInfo 
		{ BonusDamage = 4, UpgradeCost = 250 });
		ElementalBraceletStats.Add(2, new Record.ElementalBraceletInfo 
		{ BonusDamage = 8, UpgradeCost = 500 });

		BootStats.Add(0, new Record.BootInfo { Speed = 0.75f, UpgradeCost = 0 });
		BootStats.Add(1, new Record.BootInfo { Speed = 1.25f, UpgradeCost = 100 });
		BootStats.Add(2, new Record.BootInfo { Speed = 1.5f, UpgradeCost = 200 });

		PowerUpsGeneratorStats.Add(0, new Record.PowerUpsGeneratorInfo 
		{ MaxUses = 1, UpgradeCost = 100 });
		PowerUpsGeneratorStats.Add(1, new Record.PowerUpsGeneratorInfo 
		{ MaxUses = 2, UpgradeCost = 200 });
		PowerUpsGeneratorStats.Add(2, new Record.PowerUpsGeneratorInfo 
		{ MaxUses = 3, UpgradeCost = 300 });
		PowerUpsGeneratorStats.Add(3, new Record.PowerUpsGeneratorInfo 
		{ MaxUses = 4, UpgradeCost = 400 });
	}
	public Dictionary<int, Record.SwordInfo> SwordStats{ get; private set; } = new();
	public Dictionary<int, Record.BowInfo> BowStats{ get; private set; } = new();
	public Dictionary<int, Record.QuiverInfo> QuiverStats { get; private set; } = new();
	public Dictionary<int, Record.BootInfo> BootStats { get; private set; } = new();
	public Dictionary<int, Record.ElementalBraceletInfo> ElementalBraceletStats { get; private set; } = new();
	public Dictionary<int, Record.PowerUpsGeneratorInfo> PowerUpsGeneratorStats { get; private set; } = new();

}
