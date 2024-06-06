using Godot;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class ElementalBracelet : Weapon
{
	[Export]
	public Global.Element CurrentElement { get; set; } = Global.Element.None;
	public int CurrentEnergy { get; set; }
	public float BonusDamage { get; private set; } = default;
	public ElementalJar Storage { get; set; }
	[Signal]
	public delegate void CastEventHandler(int newCurrentEnergy);
	[Signal]
	public delegate void OutOfEnergyEventHandler(ElementalBracelet elementalBracelet);
	[Signal]
	public delegate void RechargeEventHandler(ElementalBracelet elementalBracelet);
	public ElementalBracelet()
	{
		this.Upgradeable = true;
		this.Level = -1;
		
	}
	public override void _Ready()
	{
		if (this.Available == true && this.Upgradeable == true)
			this.Upgrade();
		base._Ready();
		this.CoolDownTimer.WaitTime = OwnerMainCharacter.BoosterManager.ElementalCoolDown;
		this.CurrentEnergy = OwnerMainCharacter.BoosterManager.MaxEnergy;
		this.Cast += OnCast;
		if (this.Available == false)
			this.CurrentElement = Global.Element.None;
		if(this.CurrentElement == Global.Element.None)
			this.CurrentEnergy = 0;
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
		Dictionary<int, Record.ElementalBraceletInfo> ElementalBraceletStats
			= WeaponStats.GetInstance().ElementalBraceletStats;
		if (this.Level == ElementalBraceletStats.Count - 1)
			this.Upgradeable = false;
		this.BonusDamage = ElementalBraceletStats[this.Level].BonusDamage;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = ElementalBraceletStats[this.Level + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
		this.EmitSignal(Equipment.SignalName.JustUpgrade);
	}
	public void BeTaken()
	{
		this.Available = true;
		Upgrade();
		this.CurrentElement = Global.Element.None;
		this.CurrentEnergy = 0;
		this.EmitSignal(ElementalBracelet.SignalName.OutOfEnergy, this);
	}
	public void OnCast(int newCurrentEnergy)
	{
		if (this.CurrentEnergy < 0)
			this.CurrentEnergy = 0;
		if (this.CurrentEnergy == 0)
		{
			this.CurrentElement = Global.Element.None;
			this.EmitSignal(ElementalBracelet.SignalName.OutOfEnergy, this);
		}
	}
	public void Store()
	{
		if (this.Storage.Available == false)
			return;
		this.Storage.Store(this.CurrentElement, this.CurrentEnergy);
		this.CurrentElement = Global.Element.None;
		this.CurrentEnergy = 0;
		this.EmitSignal(ElementalBracelet.SignalName.OutOfEnergy, this);
	}
	public void Retrive()
	{
		if (this.Storage.Available == false)
			return;
		this.Storage.Dispose(this);
		this.Storage.Store(Global.Element.None, 0);
		this.EmitSignal(ElementalBracelet.SignalName.Recharge, this);
	}
}
