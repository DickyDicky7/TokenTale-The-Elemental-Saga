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
	private Color CheckedColor = new Color(47 / 255, 255 / 255, 67 / 255, 255 / 255);
	private Color UncheckedColor = new Color(128 / 255, 128 / 255, 128 / 255, 255 / 255);
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
		SetupBootsTracker();
		SetupQuiverTracker();
		SetupPowerupGeneratorTracker();
		SetupHealthJarTracker();
		SetupElementalJarTracker();
	}
	private void SetupBootsTracker()
	{
		int totalLevel = EquipmentStats.GetInstance().BootStats.Count;
		Boot viewerBoot = this.EquipmentManager.Boot;
		foreach(int i in Enumerable.Range(0, totalLevel))
		{
			ColorRect colorRect = new();
			SetupColorRect(colorRect);
			if (i <= viewerBoot.Level)
				colorRect.SelfModulate = CheckedColor;
			BootsTracker.TrackUnitContainer.AddChild(colorRect);

			Label label = new();
			SetupLabel(label);
			label.Text = (i + 1).ToString();
			BootsTracker.TrackLevelContainer.AddChild(label);
		}
		BootsTracker.Title.Text = "BOOTS";
		BootsTracker.Prop.Text = $"Speed: {viewerBoot.Speed}";
	}
	private void SetupQuiverTracker()
	{
		int totalLevel = EquipmentStats.GetInstance().QuiverStats.Count;
		Quiver viewerQuiver = this.EquipmentManager.Quiver;
		foreach (int i in Enumerable.Range(0, totalLevel))
		{
			ColorRect colorRect = new();
			SetupColorRect(colorRect);
			if (i <= viewerQuiver.Level)
				colorRect.SelfModulate = CheckedColor;
			QuiverTracker.TrackUnitContainer.AddChild(colorRect);

			Label label = new();
			SetupLabel(label);
			label.Text = (i + 1).ToString();
			QuiverTracker.TrackLevelContainer.AddChild(label);
		}
		QuiverTracker.Title.Text = "QUIVER";
		QuiverTracker.Prop.Text = $"Max arrow: {viewerQuiver.MaxArrow}";
	}
	private void SetupPowerupGeneratorTracker()
	{
		int totalLevel = EquipmentStats.GetInstance().PowerUpsGeneratorStats.Count;
		PowerupsGenerator viewerPowerupsGenerator = this.EquipmentManager.PowerupsGenerator;
		foreach (int i in Enumerable.Range(0, totalLevel))
		{
			ColorRect colorRect = new();
			SetupColorRect(colorRect);
			if (i <= viewerPowerupsGenerator.Level)
				colorRect.SelfModulate = CheckedColor;
			PowerupGeneratorTracker.TrackUnitContainer.AddChild(colorRect);

			Label label = new();
			SetupLabel(label);
			label.Text = (i + 1).ToString();
			PowerupGeneratorTracker.TrackLevelContainer.AddChild(label);
		}
		PowerupGeneratorTracker.Title.Text = "POWERUPS GENERATOR";
		if (viewerPowerupsGenerator.Level >= 0)
			PowerupGeneratorTracker.Prop.Text = $"Max stored uses: {viewerPowerupsGenerator.MaxUses}";
		else
			PowerupGeneratorTracker.Prop.Text = $"Max stored uses: 0";
	}
	private void SetupHealthJarTracker()
	{
		List<HealthJar> healthJarList = this.TrackingScreen.Viewer.EquipmentManager.HealthJarList;
		foreach (HealthJar healthJar in healthJarList)
		{
			TrackerHealthJar healthJarTrackerUnit = 
				HealthJarTrackerScene.Instantiate<TrackerHealthJar>();
			Label label = new();
			SetupLabel(label);
			healthJarTrackerUnit.ProgressBar.MaxValue = healthJar.MaxValue;
			healthJarTrackerUnit.ProgressBar.Value = healthJar.CurrentValue;
			if (healthJar.Available is false)
			{
				healthJarTrackerUnit.Modulate = new Color(1, 1, 1, 0.5f);
				label.Text = "Not available";
			}
			else
			{
				label.Text = $"{healthJarTrackerUnit.ProgressBar.Value}/" +
					$"{healthJarTrackerUnit.ProgressBar.MaxValue}";
			}
			this.HealthJarTracker.TrackUnitContainer.AddChild(healthJarTrackerUnit);
			this.HealthJarTracker.TrackStatsContainer.AddChild(label);
		}
	}
	private void SetupElementalJarTracker()
	{
		List<ElementalJar> elementalJarList = this.TrackingScreen.Viewer.EquipmentManager.ElementalJarList;
		foreach (ElementalJar elementalJar in elementalJarList)
		{
			TrackerElementalJar elementalJarTrackerUnit =
				ElementalJarTrackerScene.Instantiate<TrackerElementalJar>();
			Label label = new();
			SetupLabel(label);
			
			if (elementalJar.Available is false)
			{
				elementalJarTrackerUnit.Modulate = new Color(1, 1, 1, 0.5f);
				label.Text = "Not available";
			}
			else
			{
				
			}
			this.ElementalJarTracker.TrackUnitContainer.AddChild(elementalJarTrackerUnit);
			this.ElementalJarTracker.TrackStatsContainer.AddChild(label);
		}
	}
}
