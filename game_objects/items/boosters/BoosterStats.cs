using Godot;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class BoosterStats : Resource
{
	private static BoosterStats _instance;
	public static BoosterStats GetInstance()
	{
		if (_instance == null)
			_instance = new BoosterStats();
		return _instance;
	}
	private BoosterStats() : base()
	{
		//sword
		SwordProficiency.Add(0, new Record.SwordKnowledgeInfo
		{
			Speed = 2.0f,
			BonusDamageRatio = 0
		});
		SwordProficiency.Add(1, new Record.SwordKnowledgeInfo
		{
			Speed = 1.5f,
			BonusDamageRatio = 0.03f
		});
		SwordProficiency.Add(2, new Record.SwordKnowledgeInfo
		{
			Speed = 1.0f,
			BonusDamageRatio = 0.06f
		});
		SwordProficiency.Add(3, new Record.SwordKnowledgeInfo
		{
			Speed = 0.5f,
			BonusDamageRatio = 0.1f
		});
		//bow
		BowProficiency.Add(0, new Record.BowKnowledgeInfo
		{
			Speed = 2.0f,
			BonusDamageRatio = 0
		});
		BowProficiency.Add(1, new Record.BowKnowledgeInfo
		{
			Speed = 1.5f,
			BonusDamageRatio = 0.04f
		});
		BowProficiency.Add(2, new Record.BowKnowledgeInfo
		{
			Speed = 1.0f,
			BonusDamageRatio = 0.08f
		});
		//elemental
		ElementalProficiency.Add(0, new Record.ElementalKnowledgeInfo
		{
			Speed = 2.0f,
			BonusDamageRatio = 0
		});
		ElementalProficiency.Add(1, new Record.ElementalKnowledgeInfo
		{
			Speed = 1.5f,
			BonusDamageRatio = 0.04f
		});
		ElementalProficiency.Add(2, new Record.ElementalKnowledgeInfo
		{
			Speed = 1.0f,
			BonusDamageRatio = 0.08f
		});
		//health
		MaxHealthStats.Add(0, new Record.MaxHealthInfo { MaxHealth = 150 });
		MaxHealthStats.Add(1, new Record.MaxHealthInfo { MaxHealth = 170 });
		MaxHealthStats.Add(2, new Record.MaxHealthInfo { MaxHealth = 190 });
		MaxHealthStats.Add(3, new Record.MaxHealthInfo { MaxHealth = 210 });
		MaxHealthStats.Add(4, new Record.MaxHealthInfo { MaxHealth = 240 });
		MaxHealthStats.Add(5, new Record.MaxHealthInfo { MaxHealth = 270 });
		MaxHealthStats.Add(6, new Record.MaxHealthInfo { MaxHealth = 300 });
		MaxHealthStats.Add(7, new Record.MaxHealthInfo { MaxHealth = 340 });
		MaxHealthStats.Add(8, new Record.MaxHealthInfo { MaxHealth = 380 });
		//energy
		MaxEnergyStats.Add(0, new Record.MaxEnergyInfo { MaxEnergy = 10 });
		MaxEnergyStats.Add(1, new Record.MaxEnergyInfo { MaxEnergy = 12 });
		MaxEnergyStats.Add(2, new Record.MaxEnergyInfo { MaxEnergy = 14 });
		MaxEnergyStats.Add(3, new Record.MaxEnergyInfo { MaxEnergy = 16 });
		MaxEnergyStats.Add(4, new Record.MaxEnergyInfo { MaxEnergy = 19 });
		MaxEnergyStats.Add(5, new Record.MaxEnergyInfo { MaxEnergy = 22 });
		MaxEnergyStats.Add(6, new Record.MaxEnergyInfo { MaxEnergy = 25 });
		MaxEnergyStats.Add(7, new Record.MaxEnergyInfo { MaxEnergy = 29 });
		MaxEnergyStats.Add(8, new Record.MaxEnergyInfo { MaxEnergy = 33 });
	}
	public Dictionary<int, Record.SwordKnowledgeInfo> SwordProficiency { get; private set; } = new();
	public Dictionary<int, Record.BowKnowledgeInfo> BowProficiency { get; private set; } = new();
	public Dictionary<int, Record.ElementalKnowledgeInfo> ElementalProficiency { get; private set; } = new();
	public Dictionary<int, Record.MaxHealthInfo> MaxHealthStats { get; private set; } = new();
	public Dictionary<int, Record.MaxEnergyInfo> MaxEnergyStats { get; private set; } = new();
}
