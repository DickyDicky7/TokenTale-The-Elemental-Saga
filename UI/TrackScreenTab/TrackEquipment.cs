using Godot;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class TrackEquipment : PanelContainer
{
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
	[Export]
	public Trackerv2 BootsTracker { get; set; }
	[Export]
	public Trackerv2 QuiverTracker { get; set; }
	[Export]
	public Trackerv2 PowerupGeneratorTracker { get; set; }
	[Export]
	public Trackerv3 HealthJarTracker { get; set; }
	[Export]
	public Trackerv3 ElementalJarTracker { get; set; }
	[Export]
	public PackedScene HealthJarTrackerScene { get; set; }
	[Export]
	public PackedScene ElementalJarTrackerScene { get; set; }
	private Color CheckedColor = Helper.Color255ToColor1(47, 255, 67, 255);
	private Color UncheckedColor = Helper.Color255ToColor1(128, 128, 128, 255);
	private EquipmentManager EquipmentManager { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.EquipmentManager = this.TrackingScreen.Viewer.EquipmentManager;
		SetupAllTracker();
	}
	private void SetupColorRect(ColorRect colorRect)
	{
		colorRect.CustomMinimumSize = new Vector2(0, 30);
		colorRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		colorRect.SelfModulate = UncheckedColor;
	}
	private void SetupLabel(Label label)
	{
		label.CustomMinimumSize = new Vector2(0, 30);
		label.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		label.HorizontalAlignment = HorizontalAlignment.Center;
		label.VerticalAlignment = VerticalAlignment.Center;
	}
	private void SetupAllTracker()
	{
		EquipmentStats equipmentStats = EquipmentStats.GetInstance();
		SetupBootsTracker(
			equipmentStats.BootStats.Count, 
			this.EquipmentManager.Boot);
		SetupQuiverTracker(
			equipmentStats.QuiverStats.Count,
			this.EquipmentManager.Quiver);
		SetupPowerupGeneratorTracker(
			equipmentStats.PowerUpsGeneratorStats.Count,
			this.EquipmentManager.PowerupsGenerator);
		SetupHealthJarTracker();
		SetupElementalJarTracker();
	}
	private void SetupBootsTracker(int totalLevel, Boot boot)
	{
		BootsTracker.Setup(
			"BOOTS",
			$"Speed: {boot.Speed}",
			totalLevel,
			boot);
	}
	private void SetupQuiverTracker(int totalLevel, Quiver quiver)
	{
		QuiverTracker.Setup(
			"QUIVER",
			$"Max arrow: {quiver.MaxArrow}",
			totalLevel,
			quiver);
	}
	private void SetupPowerupGeneratorTracker(int totalLevel, PowerupsGenerator powerupsGenerator)
	{
		string propText = default!;
		if (powerupsGenerator.Level >= 0)
			propText = $"Max stored uses: {powerupsGenerator.MaxUses}";
		else
			propText = $"Max stored uses: 0";
		PowerupGeneratorTracker.Setup(
			"POWERUPS GENERATOR",
			propText,
			totalLevel,
			powerupsGenerator);
	}
	private void SetupHealthJarTracker()
	{
		List<HealthJar> healthJarList = this.TrackingScreen.Viewer.EquipmentManager.HealthJarList;
		foreach (HealthJar healthJar in healthJarList)
		{
			TrackerHealthJar healthJarTrackerUnit = 
				HealthJarTrackerScene.Instantiate<TrackerHealthJar>();
			healthJarTrackerUnit.ProgressBar.Value = 0;
			Label label = new();
			SetupLabel(label);
			if (healthJar.Available is false)
			{
				healthJarTrackerUnit.Modulate = new Color(1, 1, 1, 0.5f);
				label.Text = "Not available";
			}
			else
			{
				healthJarTrackerUnit.Modulate = new Color(1, 1, 1, 1);
				healthJarTrackerUnit.Update(healthJar);
			}
			this.HealthJarTracker.TrackUnitContainer.AddChild(healthJarTrackerUnit);
			this.HealthJarTracker.TrackStatsContainer.AddChild(label);
			healthJar.Action += healthJarTrackerUnit.Update;
			healthJar.Taken += () => { label.Text = string.Empty; };
		}
	}
	private void SetupElementalJarTracker()
	{
		List<ElementalJar> elementalJarList = this.TrackingScreen.Viewer.EquipmentManager.ElementalJarList;
		foreach (ElementalJar elementalJar in elementalJarList)
		{
			TrackerElementalJar elementalJarTrackerUnit =
				ElementalJarTrackerScene.Instantiate<TrackerElementalJar>();
			elementalJarTrackerUnit.ProgressBar.Value = 0;
			Label label = new();
			SetupLabel(label);
			if (elementalJar.Available is false)
			{
				elementalJarTrackerUnit.Modulate = new Color(1, 1, 1, 0.5f);
				label.Text = "Not available";
			}
			else
			{
				elementalJarTrackerUnit.Modulate = new Color(1, 1, 1, 1);
				elementalJarTrackerUnit.Update(elementalJar);
			}
			this.ElementalJarTracker.TrackUnitContainer.AddChild(elementalJarTrackerUnit);
			this.ElementalJarTracker.TrackStatsContainer.AddChild(label);
			elementalJar.Action += elementalJarTrackerUnit.Update;
			elementalJar.Taken += () => { label.Text = string.Empty; };
		}
	}
}
