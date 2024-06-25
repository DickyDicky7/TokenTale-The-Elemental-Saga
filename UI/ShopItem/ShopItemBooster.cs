using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ShopItemBooster : ShopItem
{
	[Export]
	public int Key { get; set; }
	[Export]
	public BoosterType ItemType { get; set; }
	[Export]
	public TextureRect ItemImage { get; set; }
	[Export]
	public Label ItemName { get; set; }
	[Export]
	public Texture2D HeartImage { get; set; }
	[Export]
	public Texture2D EnergyStoneImage { get; set; }
	[Export]
	public Texture2D ScrollImage { get; set; }
	private int Price { get; set; } = 0;
	public enum BoosterType
	{
		Heart,
		EnergyStone,
		SwordScroll
	}
	public override void _Ready()
	{
		base._Ready();
		SetupItemImage();
		SetupItemName();
	}
	//buy button group method
	protected override void SetupBuyButton()
	{
		this.BuyButton.Pressed += Buy;
	}
	private void Buy()
	{
		Booster booster = new Booster();
		switch (ItemType)
		{
			case BoosterType.Heart:
				booster = new Heart();
				booster.Key = this.Key;
				this.Price = 150;
				break;
			case BoosterType.EnergyStone:
				booster = new EnergyStone();
				booster.Key = this.Key;
				this.Price = 150;
				break;
			case BoosterType.SwordScroll:
				booster = new SwordScroll();
				booster.Key = this.Key;
				this.Price = 300;
				break;
		}
		if (this.ShoppingScreen.Viewer.CurrentCoin < this.Price)
		{
			this.StartWarning($"Need {this.Price} coin");
			return;
		}
		this.ShoppingScreen.Viewer.BoosterManager.TakeBooster(booster);
		this.ShoppingScreen.Viewer.CurrentCoin -= Price;
		this.ShoppingScreen.Viewer.EmitSignal(
			MainCharacter.SignalName.CoinChanged,
			this.ShoppingScreen.Viewer.CurrentCoin);
		this.BuyButton.Disabled = true;
		this.Modulate = Helper.Color255ToColor1(128, 128, 128, 128);
	}
	//textureRect itemImage group method
	private void SetupItemImage()
	{
		switch (ItemType)
		{
			case BoosterType.Heart:
				this.ItemImage.Texture = HeartImage;
				break;
			case BoosterType.EnergyStone:
				this.ItemImage.Texture = EnergyStoneImage;
				break;
			case BoosterType.SwordScroll:
				this.ItemImage.Texture = ScrollImage;
				break;
		}
	}
	//label itemName group method
	private void SetupItemName()
	{
		switch (ItemType)
		{
			case BoosterType.Heart:
				this.ItemName.Text = "Heart";
				break;
			case BoosterType.EnergyStone:
				this.ItemName.Text = "Energy Stone";
				break;
			case BoosterType.SwordScroll:
				this.ItemName.Text = "Swowrd Scroll";
				break;
		}
	}
}
