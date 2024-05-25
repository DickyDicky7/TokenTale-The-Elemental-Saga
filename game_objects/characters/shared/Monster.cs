using Godot;
using System;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Monster : Character3D
{
    [Export]
    MonsterVisitor AbilityDispatchVisitor { get; set; }
    
    [Export]
    public Global.MonsterType
                  MonsterType
    {
        get;
        set;
    }

    public Global.Element
                  ElementMark
    {
        get;
        set;
    }
    [Signal]
    public delegate void DifficultyChangedEventHandler();
    public string Key { get; protected set; }
    public float CurrentDamage { get; protected set; }
    public float Damage { get; protected set; } = 1.0f;
    public Dictionary<Type, PackedScene> AbilityPackedScenes { get; set; }
    
    public abstract void Attack(MainCharacter targetMainCharacter);
    public void CauseDamage(MainCharacter targetMainCharacter)
    {
        targetMainCharacter.CurrentHealth -= this.CurrentDamage;
        targetMainCharacter.EmitSignal(SignalName.HealthChange, this.CurrentDamage);
        this.StatusInfo.Items.Add(new StatusInfoItemElemental
        {
            Element = Global.Element.Fire, Thing = this.CurrentDamage.ToString()
        });
    }
    public virtual void PlayAbilityAnimation(MainCharacter targetMainCharacter)
    {

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
        this.DifficultyChanged += this.UpdateStats;
		UpdateStats();
		this.CurrentHealth = this.MaxHealth;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
}
