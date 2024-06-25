using Godot;
using System;
using System.Linq;
using TokenTaleTheElementalSaga;
using static TokenTaleTheElementalSaga.Global;

public partial class TrackerContainerAbility : VBoxContainer
{
	[Export]
	public Label Title { get; set; }
	[Export]
	public HBoxContainer TrackUnitContainer { get; set; }
	[Export]
	public HBoxContainer LevelLabelContainer { get; set; }
	[Export]
	public Label Prop { get; set; }
	[Export]
	public Label Exp { get; set; }
	private Color CheckedColor = Helper.Color255ToColor1(47, 255, 67, 255);
	private Color UncheckedColor = Helper.Color255ToColor1(128, 128, 128, 255);
	private ColorRect SetupColorRect(bool levelStatus)
	{
		ColorRect colorRect = new();
		colorRect.CustomMinimumSize = new Vector2(0, 30);
		colorRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		colorRect.SelfModulate = UncheckedColor;
		if (levelStatus == true)
			colorRect.SelfModulate = CheckedColor;
		return colorRect;
	}
	private Label SetupLabel(int level)
	{
		Label label = new();
		label.CustomMinimumSize = new Vector2(0, 30);
		label.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		label.HorizontalAlignment = HorizontalAlignment.Center;
		label.VerticalAlignment = VerticalAlignment.Center;
		label.Text = level.ToString();
		return label;
	}
	public void Setup(
		AbilityManager.AbilityStatus abilityStatus,
		int totalLevel,
		Global.Element element)
	{
		foreach (int i in Enumerable.Range(0, totalLevel))
		{
			ColorRect colorRect = SetupColorRect(i <= abilityStatus.CurrentLevel);
			this.TrackUnitContainer.AddChild(colorRect);
			Label label = SetupLabel(i);
			this.LevelLabelContainer.AddChild(label);
		}
		this.Title.Text = element.ToString();
		this.Prop.Text = $"Damage: {abilityStatus.AbilityInfo.Damage}";
		this.Exp.Text = $"{abilityStatus.CurrentExp}/{abilityStatus.AbilityInfo.ExpNeed}";
	}
	public void Update(AbilityManager.AbilityStatus abilityStatus, bool maxLevel)
	{
		Godot.Collections.Array<Node> TrackUnits = this.TrackUnitContainer.GetChildren();
		foreach (int i in Enumerable.Range(0, TrackUnits.Count))
		{
			if (TrackUnits[i] is ColorRect colorRect && i <= abilityStatus.CurrentLevel)
			{
				colorRect.SelfModulate = CheckedColor;
			}
		}
		this.Prop.Text = $"Damage: {abilityStatus.AbilityInfo.Damage}";
		if (maxLevel is true)
			this.Exp.Text = "Max level";
		else
			this.Exp.Text = $"{abilityStatus.CurrentExp}/{abilityStatus.AbilityInfo.ExpNeed}";
	}
}
