using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Record
{
    //Equipment
    public record SwordInfo
    {
        public float Damage      { get; set; }
        public int   UpgradeCost { get; set; }
    }

    public record BowInfo
    {
        public float Damage      { get; set; }
        public int   UpgradeCost { get; set; }
    }

    public record QuiverInfo
    {
        public int    MaxArrow { get; set; }
        public int UpgradeCost { get; set; }
    }

    public record BootInfo
    {
        public float Speed       { get; set; }
        public int   UpgradeCost { get; set; }
    }

    public record ElementalBraceletInfo
    {
        public float BonusDamage { get; set; }
        public int   UpgradeCost { get; set; }
    }

    public record PowerUpsGeneratorInfo
    {
        public int     MaxUses { get; set; }
        public int UpgradeCost { get; set; }
    }

    //Booster
    public record MaxHealthInfo
    {
        public float MaxHealth     { get; set; }
    }

    public record MaxEnergyInfo
    {
        public int MaxEnergy            { get; set; }
    }

    public record SwordKnowledgeInfo
    {
        public float CoolDown { get; set; }
        public float BonusDamageRatio { get; set; }
    }

    public record BowKnowledgeInfo
    {
        public float CoolDown { get; set; }
        public float BonusDamageRatio { get; set; }
    }

    public record ElementalKnowledgeInfo
    {
        public float CoolDown { get; set; }
        public float BonusDamageRatio { get; set; }
    }
    //ability
    public record AbilityInfo
    {
        public int   ExpNeed { get; set; }
        public float  Damage { get; set; }
    }
    //monster
    public record MonsterInfo
    {
        public float BaseMoveSpeed { get; set; }
        public float BaseMaxHealth { get; set; }
        public float BaseDamage { get; set; }
    }
    public record DifficultyScale
    {
        public float MonsterMaxHealthRatio { get; set; }
        public float MonsterBaseDamageRatio { get; set; }
    }
}
