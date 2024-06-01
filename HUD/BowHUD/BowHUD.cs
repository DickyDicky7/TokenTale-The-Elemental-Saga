using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class BowHUD : WeaponHUD
{
	[Export]
	public Label AmmoLabel { get; set; }
	private _Bow_ PartnerBow { get; set; }
	public override void Setup(Weapon chosenWeapon)
	{
		base.Setup(chosenWeapon);
		if (this.Partner is _Bow_)
			this.PartnerBow = Partner as _Bow_;
		SetupBowAmmo();
	}
	private void SetupBowAmmo()
	{
		if (this.PartnerBow is null)
			return;
		PartnerBow.Shoot += OnBowShoot;
		PartnerBow.OutOfArrow += OnBowOutOfAmmo;
		this.AmmoLabel.Text = PartnerBow.CurrentArrow.ToString();
	}
	private void OnBowShoot(int newCurrentArrow)
	{
		this.AmmoLabel.Text = newCurrentArrow.ToString();
	}
	private void OnBowOutOfAmmo()
	{
		AmmoLabel ammoLabel = this.AmmoLabel as AmmoLabel;
		ammoLabel.StartWarning();
	}
}
