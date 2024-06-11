using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ShopItemArrow : ShopItem
{
	private int ArrowPerPurchase { get; } = 5;
	private int Price { get; } = 15;
	protected override void SetupBuyButton()
	{
		this.BuyButton.Pressed += Buy;
	}
	private void Buy()
	{
		
		if (this.Price > this.ShoppingScreen.Viewer.CurrentCoin)
		{
			this.StartWarning($"Need {Price} coin!");
		}
		else 
		{
			_Bow_ bow = this.ShoppingScreen.Viewer.WeaponsController.PhysicsWeapons[1] as _Bow_;
			int spaceLeftInQuiver = this.ShoppingScreen.Viewer.EquipmentManager.Quiver.MaxArrow - bow.CurrentArrow;
			if (this.ArrowPerPurchase > spaceLeftInQuiver)
			{
				this.StartWarning("Not enough space");
			}
			else
			{
				bow.CurrentArrow += ArrowPerPurchase;
				bow.EmitSignal(_Bow_.SignalName.ArrowChanged, bow.CurrentArrow);
				this.ShoppingScreen.Viewer.CurrentCoin -= Price;
				this.ShoppingScreen.Viewer.EmitSignal(
					MainCharacter.SignalName.CoinChanged,
					this.ShoppingScreen.Viewer.CurrentCoin);
			}
		}
	}
}
