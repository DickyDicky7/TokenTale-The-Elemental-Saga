using Godot;
using System;
using System.Data;
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
    public float CurrentDamage { get; protected set; }
    public float Damage { get; protected set; } = 1.0f;
    public Timer EffectTimer { get; private set; } = new();

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
    private void OnTimerTimeOut()
    {
        this.EffectTimer.Stop();
        this.EffectTimer.WaitTime = 1.0f;
		this.CurrentSpeed = this.Speed;
		this.CurrentDamage = this.Damage;
	}
	public override void _Ready()
	{
		base._Ready();
        this.DifficultyChanged += this.UpdateStats;
		this.EffectTimer.OneShot = true;
		this.EffectTimer.WaitTime = 1.0f;
		this.EffectTimer.ProcessCallback = Timer.TimerProcessCallback.Physics;
		this.EffectTimer.Timeout += OnTimerTimeOut;
        this.AddChild(EffectTimer);
	}
}
