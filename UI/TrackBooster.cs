using Godot;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class TrackBooster : PanelContainer
{
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
	[Export]
	public Tracker HeartTracker { get; set; }
	[Export]
	public Tracker EnergyStoneTracker { get; set; }
	[Export]
	public Tracker SwordScrollTracker { get; set; }
	[Export]
	public Tracker BowScrollTracker { get; set; }
	[Export]
	public Tracker ElementalScrollTracker { get; set; }
	private Color CheckedColor = new Color(47 / 255, 255 / 255, 67 / 255, 255 / 255);
	private Color UncheckedColor = new Color(128 / 255, 128 / 255, 128 / 255, 255 / 255);
	private BoosterManager BoosterManager { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.Visible = false;
		this.BoosterManager = this.TrackingScreen.Viewer.BoosterManager;
		this.SetupAllTracker();
	}
	private void SetupColorRect(ColorRect colorRect)
	{
		colorRect.CustomMinimumSize = new Vector2(0, 30);
		colorRect.SizeFlagsHorizontal = SizeFlags.ExpandFill;
		colorRect.SelfModulate = UncheckedColor;
	}
	private void SetupAllTracker()
	{
		//heart
		SetupTracker(
			HeartTracker,
			"HEART",
			$"Max health: {this.BoosterManager.MaxHealth}",
			this.BoosterManager.HeartStatusList);
		//energy stone
		SetupTracker(
			EnergyStoneTracker,
			"ENERGY STONE",
			$"Max energy: {this.BoosterManager.MaxEnergy}",
			this.BoosterManager.EnergyStoneStatusList);
		//sword scroll
		SetupTracker(
			SwordScrollTracker,
			"SWORD SCROLL",
			$"Sword bonus damage ratio: {this.BoosterManager.SwordBonusDamageRatio}\n" + 
			$"Sword cooldown: {this.BoosterManager.SwordCoolDown}",
			this.BoosterManager.SwordScrollStatusList);
		//bow scroll
		SetupTracker(
			BowScrollTracker,
			"BOW SCROLL",
			$"Bow bonus damage ratio: {this.BoosterManager.BowBonusDamageRatio}\n" +
			$"Bow cooldown: {this.BoosterManager.BowCoolDown}",
			this.BoosterManager.BowScrollStatusList);
		//elemetnal scroll
		SetupTracker(
			ElementalScrollTracker,
			"ELEMENTAL SCROLL",
			$"Elemental bonus damage ratio: {this.BoosterManager.ElementalBonusDamageRatio}\n" +
			$"Elemental cooldown: {this.BoosterManager.ElementalCoolDown}",
			this.BoosterManager.BowScrollStatusList);
	}
	private void SetupTracker(
		Tracker tracker, 
		string title, 
		string prop, 
		List<bool> statusList)
	{
		foreach (bool status in statusList)
		{
			ColorRect colorRect = new();
			SetupColorRect(colorRect);
			if (status is true)
				colorRect.SelfModulate = CheckedColor;
			tracker.TrackUnitContainer.AddChild(colorRect);
		}
		tracker.Title.Text = title;
		tracker.Prop.Text = prop;
	}
}
