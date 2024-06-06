using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class ElementalBraceletHUD : WeaponHUD
{
	[Export]
	public TextureProgressBar ManaBar { get; set; }
	private ElementalBracelet PartnerEB { get; set; }
	private ElementalIcon ElementalIcon { get; set; }
	public void Setup(int manaBarMaxValue, Weapon chosenWeapon)
	{
		base.Setup(chosenWeapon);
		this.PartnerEB = Partner as ElementalBracelet;
		this.ElementalIcon = WeaponIcon as ElementalIcon;
		SetupManaBar(manaBarMaxValue);
		SetupIcon();
	}
	//ManaBar method group
	private void SetupManaBar(int newMaxValue)
	{
		this.ManaBar.MaxValue = newMaxValue;
		this.ManaBar.Value = this.PartnerEB.CurrentEnergy;
		this.PartnerEB.Cast += OnPartnerCast;
		this.PartnerEB.OutOfEnergy += OnPartnerRechargeOrOutOfEnergy;
		this.PartnerEB.Recharge += OnPartnerRechargeOrOutOfEnergy;
		this.PartnerEB.OwnerMainCharacter.BoosterManager.EnergyStoneChanged
			+= OnMaxEnergyChanged;
	}
	private void OnPartnerCast(int newCurrentEnergy)
	{
		this.ManaBar.Value = newCurrentEnergy;
	}
	private void OnPartnerRechargeOrOutOfEnergy(ElementalBracelet elementalBracelet)
	{
		this.ManaBar.Value = elementalBracelet.CurrentEnergy;
	}
	private void OnMaxEnergyChanged(int newMaxEnergy)
	{
		this.ManaBar.MaxValue = newMaxEnergy;
	}
	//Icon method group
	private void SetupIcon()
	{
		this.ElementalIcon.Update(this.PartnerEB.CurrentElement);
		this.PartnerEB.Recharge += UpdateIcon;
		this.PartnerEB.OutOfEnergy += UpdateIcon;
	}
	private void UpdateIcon(ElementalBracelet elementalBracelet)
	{
		this.ElementalIcon.Update(elementalBracelet.CurrentElement);
	}
}
