using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class UiControl : PanelContainer
{
	[Export]
	public MainCharacterHUDController MainCharacterHUDController { get; set; }
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
	[Export]
	public ShoppingScreen ShoppingScreen { get; set; }
	[Export]
	public ControlBoard ControlBoard { get; set; }
	private List<Control> UIList { get; set; } = new();
	private Control CurrentActiveUI { get; set; } = null;
	public override void _Ready()
	{
		base._Ready();
		this.UIList.Add(TrackingScreen);
		this.UIList.Add(ShoppingScreen);
		this.UIList.Add(ControlBoard);
	}
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventKey inputEventKey)
		{
			if (inputEventKey.Pressed)
			{
				if (inputEventKey.Keycode == Key.T)
				{
					this.TrackingScreen.Visible = !this.TrackingScreen.Visible;
					if (TrackingScreen.Visible is true)
					{
						this.CurrentActiveUI = this.TrackingScreen;
						TurnOffOtherUI();
					}
					else
					{
						this.CurrentActiveUI = null;
					}
				}
				if (inputEventKey.Keycode == Key.B)
				{
					this.ShoppingScreen.Visible = !this.ShoppingScreen.Visible;
					if (ShoppingScreen.Visible is true)
					{
						this.CurrentActiveUI = this.ShoppingScreen;
						TurnOffOtherUI();
					}
					else
					{
						this.CurrentActiveUI = null;
					}
				}
				if (inputEventKey.Keycode == Key.Escape)
				{
					if (this.CurrentActiveUI == null)
					{
						this.ControlBoard.Visible = true;
						this.CurrentActiveUI = ControlBoard;
					}
					else
					{
						this.CurrentActiveUI.Visible = false;
						this.CurrentActiveUI = null;
					}
				}
			}
		}
	}
	private void TurnOffOtherUI()
	{
		foreach (Control controlItem in UIList)
		{
			if (controlItem == CurrentActiveUI)
				continue;
			controlItem.Visible = false;
		}
	}
}
