using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class ElementalBraceletHUD : WeaponHUD
{
	[Export]
	public TextureProgressBar ManaBar { get; set; }
	private ElementalBracelet PartnerEB { get; set; }
	public override void _Process(double delta)
	{
		base._Process(delta);
	}
	public void Setup(int manaBarMaxValue, Weapon chosenWeapon)
	{
		base.Setup(chosenWeapon);
		PartnerEB = Partner as ElementalBracelet;
		SetupManaBar(manaBarMaxValue);
	}
	//ManaBar method group
	private void SetupManaBar(int newMaxValue)
	{
		this.ManaBar.MaxValue = newMaxValue;
		this.PartnerEB.Cast += OnPartnerCast;
	}
	private void OnPartnerCast(int newCurrentEnergy)
	{
		this.ManaBar.Value = newCurrentEnergy;
	}
}
