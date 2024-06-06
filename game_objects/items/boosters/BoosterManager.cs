using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class BoosterManager : Node
{
	[Signal]
	public delegate void HeartChangedEventHandler(float newMaxHealth);
	[Signal]
	public delegate void EnergyStoneChangedEventHandler(int newMaxEnergy);
	[Signal]
	public delegate void SwordScollChangedEventHandler(
		float newSwordCooldown, 
		float newSwordBonusDamageRatio);
	[Signal]
	public delegate void BowScrollChangedEventHandler(
		float newBowCooldown,
		float newBowBonusDamageRatio);
	[Signal]
	public delegate void ElementalScrollChangedEventHandler(
		float newElementalCoolDown,
		float newElementalBonusDamageRatio);
	private MainCharacter MainCharacter { get; set; }
	public List<bool> HeartStatusList = new();
	public List<bool> EnergyStoneStatusList = new();
	public List<bool> SwordScrollStatusList = new();
	public List<bool> BowScrollStatusList = new();
	public List<bool> ElementalScrollStatusList = new();

	public float MaxHealth { get; private set; }
	public int MaxEnergy { get; private set; }
	public float SwordCoolDown { get; private set; }
	public float SwordBonusDamageRatio { get; private set; }
	public float BowCoolDown { get; private set; }
	public float BowBonusDamageRatio { get; private set; }
	public float ElementalCoolDown { get; private set; }
	public float ElementalBonusDamageRatio { get; private set; }

	public BoosterManager(MainCharacter mainCharacter)
	{
		this.MainCharacter = mainCharacter;
		foreach (int i in Enumerable.Range(0, 8))
		{
			if (i % 2 == 0)
				HeartStatusList.Add(false);
			else
				HeartStatusList.Add(true);
			EnergyStoneStatusList.Add(false);
			if (i <= 3)
				SwordScrollStatusList.Add(false);
			if (i <= 2)
			{
				BowScrollStatusList.Add(false);
				ElementalScrollStatusList.Add(false);
			}
		}
		ApplyHeart();
		ApplyPowerStone();
		ApplySwordScroll();
		ApplyBowScroll();
		ApplyElementalScroll();
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
		this.MainCharacter.MaxHealth = this.MaxHealth;
		this.EmitSignal(BoosterManager.SignalName.HeartChanged, this.MaxHealth);
	}
	private void ApplyPowerStone()
	{
		int EnergyStoneCollected = EnergyStoneStatusList.FindAll(x => x == true).Count;
		this.MaxEnergy = BoosterStats.GetInstance()
			.MaxEnergyStats[EnergyStoneCollected]
			.MaxEnergy;
		this.EmitSignal(BoosterManager.SignalName.EnergyStoneChanged, this.MaxEnergy);
	}
	private void ApplySwordScroll()
	{
		int SwordScrollCollected = SwordScrollStatusList.FindAll(x => x == true).Count;
		Record.SwordKnowledgeInfo info = BoosterStats.GetInstance()
			.SwordProficiency[SwordScrollCollected];
		this.SwordCoolDown = info.CoolDown;
		this.SwordBonusDamageRatio = info.BonusDamageRatio;
		this.EmitSignal(
			BoosterManager.SignalName.SwordScollChanged,
			this.SwordCoolDown,
			this.SwordBonusDamageRatio);
	}
	private void ApplyBowScroll()
	{
		int BowScrollCollected = BowScrollStatusList.FindAll(x => x == true).Count;
		Record.BowKnowledgeInfo info = BoosterStats.GetInstance()
			.BowProficiency[BowScrollCollected];
		this.BowCoolDown = info.CoolDown;
		this.BowBonusDamageRatio = info.BonusDamageRatio;
		this.EmitSignal(
			BoosterManager.SignalName.BowScrollChanged,
			this.BowCoolDown,
			this.BowBonusDamageRatio);
	}
	private void ApplyElementalScroll()
	{
		int ElementalScrollCollected = ElementalScrollStatusList.FindAll(x => x == true).Count;
		Record.ElementalKnowledgeInfo info = BoosterStats.GetInstance()
			.ElementalProficiency[ElementalScrollCollected];
		this.ElementalCoolDown = info.CoolDown;
		this.ElementalBonusDamageRatio = info.BonusDamageRatio;
		this.EmitSignal(
			BoosterManager.SignalName.ElementalScrollChanged,
			this.ElementalCoolDown,
			this.ElementalBonusDamageRatio);
	}
}
