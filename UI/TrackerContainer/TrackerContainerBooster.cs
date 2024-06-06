using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
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
	private ColorRect SetupColorRect(bool status)
	{
		ColorRect colorRect = new();
		colorRect.CustomMinimumSize = new Vector2(0, 30);
		colorRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		colorRect.SelfModulate = UncheckedColor;
		if (status is true)
			colorRect.SelfModulate = CheckedColor;
		return colorRect;
	}
	public void Setup(string title, string prop, List<bool> statusList)
	{
		foreach (bool status in statusList)
		{
			ColorRect colorRect = SetupColorRect(status);
			this.TrackUnitContainer.AddChild(colorRect);
		}
		this.Title.Text = title;
		this.Prop.Text = prop;
	}
	public void Update(string prop, List<bool> statusList)
	{
		Godot.Collections.Array<Node> TrackerUnits = this.TrackUnitContainer.GetChildren();
		foreach (int i in Enumerable.Range(0, TrackerUnits.Count))
		{
			if (TrackerUnits[i] is ColorRect colorRect)
			{
				if (statusList[i] is true)
				{
					colorRect.SelfModulate = CheckedColor;
				}
			}
		}
		this.Prop.Text = prop;
	}
}
