using Godot;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;

public partial class WeaponStats : Resource
{
	private static WeaponStats _instance;
	public static WeaponStats GetInstance()
	{
		if (_instance == null)
			_instance = new WeaponStats();
		return _instance;
	}
	private WeaponStats() : base()
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

		ElementalBraceletStats.Add(0, new Record.ElementalBraceletInfo
		{ BonusDamage = 0, UpgradeCost = 0 });
		ElementalBraceletStats.Add(1, new Record.ElementalBraceletInfo
		{ BonusDamage = 4, UpgradeCost = 250 });
		ElementalBraceletStats.Add(2, new Record.ElementalBraceletInfo
		{ BonusDamage = 8, UpgradeCost = 500 });
	}
	public Dictionary<int, Record.SwordInfo> SwordStats { get; private set; } = new();
	public Dictionary<int, Record.BowInfo> BowStats { get; private set; } = new();
	public Dictionary<int, Record.ElementalBraceletInfo> ElementalBraceletStats { get; private set; } = new();
}
