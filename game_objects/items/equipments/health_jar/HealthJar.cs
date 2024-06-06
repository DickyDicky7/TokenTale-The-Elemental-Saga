using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class HealthJar : Equipment
{
	public int Key { get; private set; } = default;
	public float MaxValue { get; private set; }
	public float CurrentValue { get; private set; } = 0;
	[Signal]
	public delegate void ActionEventHandler(HealthJar healthJar);
	[Signal]
	public delegate void TakenEventHandler();
	public HealthJar(int Key, bool available,MainCharacter mainCharacter)
	{
		this.Available = available;
		this.Upgradeable = false;
		this.Level = -1;
		this.Key = Key;
		this.OwnerMainCharacter = mainCharacter;
		this.MaxValue = mainCharacter.MaxHealth * 0.7f;
	}
	public override void _Ready()
	{
		base._Ready();
		this.OwnerMainCharacter.BoosterManager.HeartChanged += UpdateMaxValue;
	}
	public void BeTaken()
	{
		this.Available = true;
		this.EmitSignal(HealthJar.SignalName.Action, this);
		this.EmitSignal(HealthJar.SignalName.Taken);
	}
	public void UpdateMaxValue(float newMaxValue)
	{
		this.MaxValue = newMaxValue * 0.7f;
		this.EmitSignal(HealthJar.SignalName.Action, this);
	}
	public float Store(float Value)
	{
		float excessAmount = 0;
		this.CurrentValue += Value;
		if (this.CurrentValue > this.MaxValue)
		{
			excessAmount = this.CurrentValue -= MaxValue;
			this.CurrentValue = this.MaxValue;
		}
		this.EmitSignal(HealthJar.SignalName.Action, this);
		return excessAmount;
	}
	public float Retrive(float value)
	{
		if (value <= CurrentValue)
		{
			CurrentValue -= value;
			this.EmitSignal(HealthJar.SignalName.Action, this);
			return value;
		}
		else
		{
			float temp = this.CurrentValue;
			this.CurrentValue = 0;
			this.EmitSignal(HealthJar.SignalName.Action, this);
			return temp;
		}

	}
}
