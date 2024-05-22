using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class ItemStats : Resource
{
	private static ItemStats _instance;
	public static ItemStats GetInstance()
	{
		if (_instance == null)
			_instance = new ItemStats();
		return _instance;
	}
	private ItemStats() : base()
	{
		SwordStats.Add(new Record.SwordInfo { Level = 0, Damage = 10, UpgradeCost = 0 });
		SwordStats.Add(new Record.SwordInfo { Level = 1, Damage = 13, UpgradeCost = 100 });
		SwordStats.Add(new Record.SwordInfo { Level = 2, Damage = 16, UpgradeCost = 150 });
		SwordStats.Add(new Record.SwordInfo { Level = 3, Damage = 19, UpgradeCost = 200 });
		SwordStats.Add(new Record.SwordInfo { Level = 4, Damage = 22, UpgradeCost = 250 });

		BowStats.Add(new Record.BowInfo { Level = 0, Damage = 10, UpgradeCost = 0 });
		BowStats.Add(new Record.BowInfo { Level = 1, Damage = 14, UpgradeCost = 100 });
		BowStats.Add(new Record.BowInfo { Level = 2, Damage = 18, UpgradeCost = 175 });
		BowStats.Add(new Record.BowInfo { Level = 3, Damage = 22, UpgradeCost = 250 });
		BowStats.Add(new Record.BowInfo { Level = 4, Damage = 26, UpgradeCost = 325 });

		QuiverStats.Add(new Record.QuiverInfo { Level = 0, MaxArrow = 15, UpgradeCost = 0 });
		QuiverStats.Add(new Record.QuiverInfo { Level = 1, MaxArrow = 30, UpgradeCost = 50 });
		QuiverStats.Add(new Record.QuiverInfo { Level = 2, MaxArrow = 45, UpgradeCost = 90 });
		QuiverStats.Add(new Record.QuiverInfo { Level = 3, MaxArrow = 60, UpgradeCost = 140 });
		QuiverStats.Add(new Record.QuiverInfo { Level = 4, MaxArrow = 75, UpgradeCost = 200 });

		ElementalBraceletStats.Add(new Record.ElementalBraceletInfo 
		{ Level = 0, BonusDamage = 0, UpgradeCost = 0 });
		ElementalBraceletStats.Add(new Record.ElementalBraceletInfo 
		{ Level = 1, BonusDamage = 4, UpgradeCost = 250 });
		ElementalBraceletStats.Add(new Record.ElementalBraceletInfo 
		{ Level = 2, BonusDamage = 8, UpgradeCost = 500 });

		BootStats.Add(new Record.BootInfo { Level = 0, Speed = 0.75f, UpgradeCost = 0 });
		BootStats.Add(new Record.BootInfo { Level = 1, Speed = 1.25f, UpgradeCost = 100 });
		BootStats.Add(new Record.BootInfo { Level = 2, Speed = 1.5f, UpgradeCost = 200 });

		PowerUpsGeneratorStats.Add(new Record.PowerUpsGeneratorInfo 
		{ Level = 0, MaxUses = 1, UpgradeCost = 100 });
		PowerUpsGeneratorStats.Add(new Record.PowerUpsGeneratorInfo 
		{ Level = 1, MaxUses = 2, UpgradeCost = 200 });
		PowerUpsGeneratorStats.Add(new Record.PowerUpsGeneratorInfo 
		{ Level = 2, MaxUses = 3, UpgradeCost = 300 });
		PowerUpsGeneratorStats.Add(new Record.PowerUpsGeneratorInfo 
		{ Level = 3, MaxUses = 4, UpgradeCost = 400 });
	}
	public List<Record.SwordInfo> SwordStats{ get; private set; } = new();
	public List<Record.BowInfo> BowStats{ get; private set; } = new();
	public List<Record.QuiverInfo> QuiverStats { get; private set; } = new();
	public List<Record.BootInfo> BootStats { get; private set; } = new();
	public List<Record.ElementalBraceletInfo> ElementalBraceletStats { get; private set; } = new();
	public List<Record.PowerUpsGeneratorInfo> PowerUpsGeneratorStats { get; private set; } = new();

}
