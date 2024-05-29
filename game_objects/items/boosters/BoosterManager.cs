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
	public float SwordCoolDown { get; private set; }
	public float SwordBonusDamageRatio { get; private set; }
	public float BowCoolDown { get; private set; }
	public float BowBonusDamageRatio { get; private set; }
	public float ElementalCoolDown { get; private set; }
	public float ElementalBonusDamageRatio { get; private set; }

	public BoosterManager()
	{
		foreach (int i in Enumerable.Range(0, 8))
		{
			HeartStatusList.Add(false);
			EnergyStoneStatusList.Add(false);
			if (i <= 3)
				SwordScrollStatusList.Add(false);
			if (i <= 2)
			{
				BowScrollStatusList.Add(false);
				ElementalScrollStatusList.Add(false);
			}
		}
		BoosterStats BoosterStats = BoosterStats.GetInstance();
		MaxHealth = BoosterStats.MaxHealthStats[0].MaxHealth;
		MaxEnergy = BoosterStats.MaxEnergyStats[0].MaxEnergy;
		SwordCoolDown = BoosterStats.SwordProficiency[0].CoolDown;
		SwordBonusDamageRatio = BoosterStats.SwordProficiency[0].BonusDamageRatio;
		BowCoolDown = BoosterStats.BowProficiency[0].CoolDown;
		BowBonusDamageRatio = BoosterStats.BowProficiency[0].BonusDamageRatio;
		ElementalCoolDown = BoosterStats.ElementalProficiency[0].CoolDown;
		ElementalBonusDamageRatio = BoosterStats.ElementalProficiency[0].BonusDamageRatio;
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
		this.MaxHealth = BoosterStats.GetInstance()
			.MaxHealthStats[HeartCollected]
			.MaxHealth;
	}
	private void ApplyPowerStone()
	{
		int EnergyStoneCollected = EnergyStoneStatusList.FindAll(x => x == true).Count;
		this.MaxEnergy = BoosterStats.GetInstance()
			.MaxEnergyStats[EnergyStoneCollected]
			.MaxEnergy;
	}
	private void ApplySwordScroll()
	{
		int SwordScrollCollected = SwordScrollStatusList.FindAll(x => x == true).Count;
		Record.SwordKnowledgeInfo info = BoosterStats.GetInstance()
			.SwordProficiency[SwordScrollCollected];
		this.SwordCoolDown = info.CoolDown;
		this.SwordBonusDamageRatio = info.BonusDamageRatio;
	}
	private void ApplyBowScroll()
	{
		int BowScrollCollected = BowScrollStatusList.FindAll(x => x == true).Count;
		Record.BowKnowledgeInfo info = BoosterStats.GetInstance()
			.BowProficiency[BowScrollCollected];
		this.BowCoolDown = info.CoolDown;
		this.BowBonusDamageRatio = info.BonusDamageRatio;
	}
	private void ApplyElementalScroll()
	{
		int ElementalScrollCollected = ElementalScrollStatusList.FindAll(x => x == true).Count;
		Record.ElementalKnowledgeInfo info = BoosterStats.GetInstance()
			.ElementalProficiency[ElementalScrollCollected];
		this.ElementalCoolDown = info.CoolDown;
		this.ElementalBonusDamageRatio = info.BonusDamageRatio;
	}
}
