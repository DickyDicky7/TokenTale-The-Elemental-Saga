using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class HealthJar : Equipment
{
	public int Key { get; private set; }
	public float MaxValue { get; private set; }
	public float CurrentValue { get; private set; }
	public HealthJar(int Key)
	{
		this.Available = false;
		this.Upgradeable = false;
		this.Level = -1;
		this.Key = Key;
	}
	public void BeTaken()
	{
		this.Available = true;
	}
	public void UpdateMaxValue(float NewMaxValue)
	{
		this.MaxValue = NewMaxValue;
	}
	public void Store(float Value)
	{
		this.CurrentValue += Value;
		if (this.CurrentValue > this.MaxValue)
			this.CurrentValue = this.MaxValue;
	}
	public float Retrive(float Value)
	{
		if (Value <= CurrentValue)
		{
			CurrentValue -= Value;
			return Value;
		}
		else
		{
			float temp = this.CurrentValue;
			this.CurrentValue = 0;
			return temp;
		}
	}
}