using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class TrackerContainerBooster : VBoxContainer
{
	[Export]
	public Label Title { get; set; }
	[Export]
	public HBoxContainer TrackUnitContainer { get; set; }
	[Export]
	public Label Prop { get; set; }
	private Color CheckedColor = Helper.Color255ToColor1(47, 255, 67, 255);
	private Color UncheckedColor = Helper.Color255ToColor1(128, 128, 128, 255);
	private void SetupColorRect(ColorRect colorRect, bool status)
	{
		colorRect.CustomMinimumSize = new Vector2(0, 30);
		colorRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		colorRect.SelfModulate = UncheckedColor;
		if (status is true)
			colorRect.SelfModulate = CheckedColor;
	}
	public void Setup(string title, string prop, List<bool> statusList)
	{
		foreach (bool status in statusList)
		{
			ColorRect colorRect = new();
			SetupColorRect(colorRect, status);
			this.TrackUnitContainer.AddChild(colorRect);
		}
		this.Title.Text = title;
		this.Prop.Text = prop;
	}
	
}
