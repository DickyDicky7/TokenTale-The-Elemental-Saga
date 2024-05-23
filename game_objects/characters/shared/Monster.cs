using Godot;
using System;
using System.Runtime.InteropServices;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Monster : Character3D
{
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
    public float Damage { get; protected set; }

    public abstract void Attack(Character3D @target);
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
	}
}
