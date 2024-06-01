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
	[Signal]
	public delegate void CastEventHandler(int newCurrentEnergy);
	[Signal]
	public delegate void OutOfEnergyEventHandler();
	public ElementalBracelet()
	{
		this.Upgradeable = true;
		this.Level = -1;
		if (this.Available == true && this.Upgradeable == true)
			this.Upgrade();
	}
	public override void _Ready()
	{
		base._Ready();
		this.CoolDownTimer.WaitTime = OwnerMainCharacter.BoosterManager.ElementalCoolDown;
		this.CurrentEnergy = OwnerMainCharacter.BoosterManager.MaxEnergy;
		this.OutOfEnergy += OnOutOfEnergy;
		this.Cast += OnCast;
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
	}
	public void BeTaken()
	{
		this.Available = true;
		Upgrade();
	}
	public void OnOutOfEnergy()
	{
		this.CurrentElement = Global.Element.None;
	}
	public void OnCast(int newCurrentEnergy)
	{
		this.CurrentEnergy = newCurrentEnergy;
		if (this.CurrentEnergy < 0)
			this.CurrentEnergy = 0;
		if (this.CurrentEnergy == 0)
			this.EmitSignal(ElementalBracelet.SignalName.OutOfEnergy);
	}
}
