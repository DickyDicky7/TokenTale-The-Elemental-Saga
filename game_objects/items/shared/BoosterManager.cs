using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class BoosterManager : Node
{
	private List<bool> HeartStatusList = new();
	private List<bool> EnergyStoneStatusList = new();
	private List<bool> SwordScrollStatusList = new();
	private List<bool> BowScrollStatusList = new();
	private List<bool> ElementalScrollStatusList = new();

	public float MaxHealth { get; private set; }
	public int MaxEnergy { get; private set; }
	public float SwordAttackSpeed { get; private set; }
	public float SwordBonusDamageRatio { get; private set; }
	public float BowAttackSpeed { get; private set; }
	public float BowBonusDamageRatio { get; private set; }
	public float ElementalCastSpeed { get; private set; }
	public float ElementalBonusDamageRatio { get; private set; }

	public BoosterManager()
	{
		foreach (int i in Enumerable.Range(0, 8))
		{
			HeartStatusList.Add(false);
			EnergyStoneStatusList.Add(false);
			if (i <= 2)
				SwordScrollStatusList.Add(false);
			if (i <= 1)
			{
				BowScrollStatusList.Add(false);
				ElementalScrollStatusList.Add(false);
			}
		}
		MaxHealth = MainCharacterStats.MaxHealthStats[0].MaxHealth;
		MaxEnergy = MainCharacterStats.MaxEnergyStats[0].MaxEnergy;
		SwordAttackSpeed = MainCharacterStats.SwordProficiency[0].Speed;
		SwordBonusDamageRatio = MainCharacterStats.SwordProficiency[0].BonusDamageRatio;
		BowAttackSpeed = MainCharacterStats.BowProficiency[0].Speed;
		BowBonusDamageRatio = MainCharacterStats.BowProficiency[0].BonusDamageRatio;
		ElementalCastSpeed = MainCharacterStats.ElementalProficiency[0].Speed;
		ElementalBonusDamageRatio = MainCharacterStats.ElementalProficiency[0].BonusDamageRatio;
	}
	public void TakeBooster(Booster booster)
	{
		if (booster.GetType() == typeof(Heart))
		{
			HeartStatusList[booster.Key] = true;
			ApplyHeart();
		}
		else if (booster.GetType() == typeof(EnergyStone))
		{
			EnergyStoneStatusList[booster.Key] = true;
			ApplyPowerStone();
		}
		else if (booster.GetType() == typeof(SwordScroll))
		{
			SwordScrollStatusList[booster.Key] = true;
			ApplySwordScroll();
		}
		else if (booster.GetType() == typeof(BowScroll))
		{
			BowScrollStatusList[booster.Key] = true;
			ApplyBowScroll();
		}
		else if (booster.GetType() == typeof(ElementalScroll))
		{
			ElementalScrollStatusList[booster.Key] = true;
			ApplyElementalScroll();
		}
	}
	private void ApplyHeart()
	{
		int HeartCollected = HeartStatusList.FindAll(x => x == true).Count;
		this.MaxHealth = MainCharacterStats
			.MaxHealthStats
			.First(x => x.HeartColleted == HeartCollected)
			.MaxHealth;
	}
	private void ApplyPowerStone()
	{
		int EnergyStoneCollected = EnergyStoneStatusList.FindAll(x => x == true).Count;
		this.MaxEnergy = MainCharacterStats
			.MaxEnergyStats
			.First(x => x.EnergyStoneCollected == EnergyStoneCollected)
			.MaxEnergy;
	}
	private void ApplySwordScroll()
	{
		int SwordScrollCollected = SwordScrollStatusList.FindAll(x => x == true).Count;
		Record.SwordKnowledgeInfo info = MainCharacterStats
			.SwordProficiency
			.First(x => x.SwordScrollCollected == SwordScrollCollected);
		this.SwordAttackSpeed = info.Speed;
		this.SwordBonusDamageRatio = info.BonusDamageRatio;
	}
	private void ApplyBowScroll()
	{
		int BowScrollCollected = BowScrollStatusList.FindAll(x => x == true).Count;
		Record.BowKnowledgeInfo info = MainCharacterStats
			.BowProficiency
			.First(x => x.BowScrollCollected == BowScrollCollected);
		this.BowAttackSpeed = info.Speed;
		this.BowBonusDamageRatio = info.BonusDamageRatio;
	}
	private void ApplyElementalScroll()
	{
		int ElementalScrollCollected = ElementalScrollStatusList.FindAll(x => x == true).Count;
		Record.ElementalKnowledgeInfo info = MainCharacterStats
			.ElementalProficiency
			.First(x => x.ElementalScrollCollected == ElementalScrollCollected);
		this.ElementalCastSpeed = info.Speed;
		this.ElementalBonusDamageRatio = info.BonusDamageRatio;
	}
}
