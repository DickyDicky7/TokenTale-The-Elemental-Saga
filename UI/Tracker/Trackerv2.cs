using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class Trackerv2 : VBoxContainer
{
	[Export]
	public Label Title { get; set; }
	[Export]
	public HBoxContainer TrackUnitContainer { get; set; }
	[Export]
	public HBoxContainer TrackLevelContainer { get; set; }
	[Export]
	public Label Prop { get; set; }
	private Color CheckedColor = Helper.Color255ToColor1(47, 255, 67, 255);
	private Color UncheckedColor = Helper.Color255ToColor1(128, 128, 128, 255);
	private void SetupColorRect(ColorRect colorRect, bool levelStatus)
	{
		colorRect.CustomMinimumSize = new Vector2(0, 30);
		colorRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		colorRect.SelfModulate = UncheckedColor;
		if (levelStatus == true)
			colorRect.SelfModulate = CheckedColor;
	}
	private void SetupLabel(Label label, int level)
	{
		label.CustomMinimumSize = new Vector2(0, 30);
		label.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		label.HorizontalAlignment = HorizontalAlignment.Center;
		label.VerticalAlignment = VerticalAlignment.Center;
		label.Text = level.ToString();
	}
	public void Setup(string title, string prop, int totalLevel, Equipment equipment)
	{
		foreach (int i in Enumerable.Range(0, totalLevel))
		{
			ColorRect colorRect = new();
			SetupColorRect(colorRect, i <= equipment.Level);
			this.TrackUnitContainer.AddChild(colorRect);

			Label label = new();
			SetupLabel(label, i + 1);
			this.TrackLevelContainer.AddChild(label);
		}
		this.Title.Text = title;
		this.Prop.Text = prop;
	}
}
