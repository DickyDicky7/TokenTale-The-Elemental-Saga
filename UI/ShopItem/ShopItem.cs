using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public abstract partial class ShopItem : MarginContainer
{
	[Export]
	public Button BuyButton { get; set; }
	public ShoppingScreen ShoppingScreen { get; set; }
	protected string BuyButtonNormalText { get; private set; } = "Buy";
	protected Color WarningColor = Helper.Color255ToColor1(204, 51, 0, 255);
	protected Color NormalColor = Helper.Color255ToColor1(255, 255, 255, 255);
	private Timer WarningTimer { get; set; } = new();
	public override void _Ready()
	{
		base._Ready();
		SetupBuyButton();
		SetupTimer();
	}
	protected abstract void SetupBuyButton();
	private void SetupTimer()
	{
		this.WarningTimer.OneShot = true;
		this.WarningTimer.WaitTime = 1.0d;
		this.WarningTimer.ProcessCallback = Timer.TimerProcessCallback.Physics;
		this.WarningTimer.Timeout += EndWarning;
		this.AddChild(WarningTimer);
	}
	protected void StartWarning(string buttonText)
	{
		this.WarningTimer.Start();
		this.BuyButton.Text = buttonText;
		this.BuyButton.SelfModulate = WarningColor;
	}
	protected void EndWarning()
	{
		this.WarningTimer.Stop();
		this.BuyButton.Text = BuyButtonNormalText;
		this.BuyButton.SelfModulate = NormalColor;
	}
}
