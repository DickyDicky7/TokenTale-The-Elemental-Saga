using Godot;
using System;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

[Tool]
[GlobalClass]
public abstract partial class Monster : Character3D
{
    [Export]
    public MonsterVisitor AbilityDispatchVisitor { get; set; }
    [Export]
    public NavigationRegion3D NavigationRegion3DStatic { get; set; }
    
    [Export]
    public Global.MonsterType
                  MonsterType
    {
        get;
        set;
    }
    [Signal]
    public delegate void DifficultyChangedEventHandler();
    public string Key { get; protected set; }
    public float CurrentDamage { get; protected set; }
    public float Damage { get; protected set; } = 1.0f;
    public Dictionary<string, PackedScene> AbilityPackedScenes { get; set; } = new();
    
    public abstract void Attack(MainCharacter targetMainCharacter);
    public abstract void AcceptVisitor(MonsterVisitor visitor);
    public abstract void CreateAbility(MainCharacter targetMainCharacter);
	public override float CalculateDamage(Ability3D ability, Character3D targetCharacter)
	{
        float damage = 0;
        if (targetCharacter is not MainCharacter)
            return damage;
        damage = this.CurrentDamage * ability.DamageRatio;
        BaseDH elementalReactionDH = null;
        if (targetCharacter.ElementMark == Global.Element.None)
        {
			targetCharacter.ElementMark = ability.Element;
        }
        else
        {
            elementalReactionDH = new ElementalReactionDH(
                targetCharacter.ElementMark,
                ability.Element,
                false);
            targetCharacter.ElementMark = Global.Element.None;
        }
        if (elementalReactionDH != null)
            elementalReactionDH.ProcessDamage(ref damage);
        return damage;
	}
	public void UpdateStats()
    {
        Record.MonsterInfo MonsterInfo = MonsterStats.GetInstance()
            .Monster[this.Key];
        Record.DifficultyScale Difficulty= GameManager.GetInstance()
            .MonsterManager
            .CurrentDifficulty;
        this.Damage = MonsterInfo.BaseDamage * Difficulty.MonsterBaseDamageRatio;
        this.MaxHealth = MonsterInfo.BaseMaxHealth * Difficulty.MonsterMaxHealthRatio;
        this.Speed = MonsterInfo.BaseMoveSpeed;
	}
	public override void _Ready()
	{
		base._Ready();
        //init ability resource
        AbilityDispatchVisitor.Init();
        this.AcceptVisitor(this.AbilityDispatchVisitor);
        //update stats base on difficulty
        this.DifficultyChanged += this.UpdateStats;
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
