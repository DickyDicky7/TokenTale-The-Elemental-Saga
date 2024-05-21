using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class MainCharacterStats : Resource
{
	private MainCharacterStats() : base()
	{
		SwordProficiency.Add(new Record.SwordKnowledgeInfo
		{
			SwordScrollCollected = 0,
			Speed = 2.0f,
			BonusDamageRatio = 0
		});
		SwordProficiency.Add(new Record.SwordKnowledgeInfo
		{
			SwordScrollCollected = 1,
			Speed = 1.5f,
			BonusDamageRatio = 0.03f
		});
		SwordProficiency.Add(new Record.SwordKnowledgeInfo
		{
			SwordScrollCollected = 2,
			Speed = 1.0f,
			BonusDamageRatio = 0.06f
		});
		SwordProficiency.Add(new Record.SwordKnowledgeInfo
		{
			SwordScrollCollected = 3,
			Speed = 0.5f,
			BonusDamageRatio = 0.1f
		});

		BowProficiency.Add(new Record.BowKnowledgeInfo
		{
			BowScrollCollected = 0,
			Speed = 2.0f,
			BonusDamageRatio = 0
		});
		BowProficiency.Add(new Record.BowKnowledgeInfo
		{
			BowScrollCollected = 1,
			Speed = 1.5f,
			BonusDamageRatio = 0.04f
		});
		BowProficiency.Add(new Record.BowKnowledgeInfo
		{
			BowScrollCollected = 2,
			Speed = 1.0f,
			BonusDamageRatio = 0.08f
		});

		ElementalProficiency.Add(new Record.ElementalKnowledgeInfo
		{
			ElementalScrollCollected = 0,
			Speed = 2.0f,
			BonusDamageRatio = 0
		});
		ElementalProficiency.Add(new Record.ElementalKnowledgeInfo
		{
			ElementalScrollCollected = 1,
			Speed = 1.5f,
			BonusDamageRatio = 0.04f
		});
		ElementalProficiency.Add(new Record.ElementalKnowledgeInfo
		{
			ElementalScrollCollected = 2,
			Speed = 1.0f,
			BonusDamageRatio = 0.08f
		});

		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 0, MaxHealth = 150 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 1, MaxHealth = 170 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 2, MaxHealth = 190 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 3, MaxHealth = 210 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 4, MaxHealth = 240 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 5, MaxHealth = 270 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 6, MaxHealth = 300 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 7, MaxHealth = 340 });
		MaxHealthStats.Add(new Record.MaxHealthInfo { HeartColleted = 8, MaxHealth = 380 });

		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 0, MaxEnergy = 10 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 1, MaxEnergy = 12 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 2, MaxEnergy = 14 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 3, MaxEnergy = 16 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 4, MaxEnergy = 19 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 5, MaxEnergy = 22 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 6, MaxEnergy = 25 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 7, MaxEnergy = 29 });
		MaxEnergyStats.Add(new Record.MaxEnergyInfo { EnergyStoneCollected = 8, MaxEnergy = 33 });
	}
	private static MainCharacterStats _instance;
	public static MainCharacterStats GetInstance()
	{
		if (_instance is null)
			_instance = new MainCharacterStats();
		return _instance;
	}
	public static List<Record.SwordKnowledgeInfo> SwordProficiency { get; private set; }
	public static List<Record.BowKnowledgeInfo> BowProficiency { get; private set; }
	public static List<Record.ElementalKnowledgeInfo> ElementalProficiency { get; private set; }
	public static List<Record.MaxHealthInfo> MaxHealthStats { get; private set; }
	public static List<Record.MaxEnergyInfo> MaxEnergyStats { get; private set; }
}
