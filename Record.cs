using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class Record
{
	//Equipment
	public record SwordInfo
	{
		public int Level { get; set; }
		public float Damage { get; set; }
		public int UpgradeCost { get; set; }
	}
	public record BowInfo
	{
		public int Level { get; set; }
		public float Damage { get; set; }
		public int UpgradeCost { get; set; }
	}
	public record QuiverInfo
	{
		public int Level { get; set; }
		public int MaxArrow { get; set; }
		public int UpgradeCost { get; set; }
	}
	public record BootInfo
	{
		public int Level { get; set; }
		public float Speed { get; set; }
		public int UpgradeCost { get; set; }
	}
	public record ElementalBraceletInfo
	{
		public int Level { get; set; }
		public float BonusDamage { get; set; }
		public int UpgradeCost { get; set; }
	}
	public record PowerUpsGeneratorInfo
	{
		public int Level { get; set; }
		public int MaxUses { get; set; }
		public int UpgradeCost { get; set; }
	}
	//Booster
	public record MaxHealthInfo
	{
		public int HeartColleted { get; set; }
		public float MaxHealth { get; set; }
	}
	public record MaxEnergyInfo
	{
		public int EnergyStoneCollected { get; set; }
		public int MaxEnergy { get; set; }
	}
	public record SwordKnowledgeInfo
	{
		public int SwordScrollCollected { get; set; }
		public float Speed { get; set; }
		public float BonusDamageRatio { get; set; }
	}
	public record BowKnowledgeInfo
	{
		public int BowScrollCollected { get; set; }
		public float Speed { get; set; }
		public float BonusDamageRatio { get; set; }
	}
	public record ElementalKnowledgeInfo
	{
		public int ElementalScrollCollected { get; set; }
		public float Speed { get; set; }
		public float BonusDamageRatio { get; set; }
	}
	public record AbilityInfo
	{
		public int Level { get; set; }
		public int ExpNeed { get; set; }
		public float Damage { get; set; }
	}
}
