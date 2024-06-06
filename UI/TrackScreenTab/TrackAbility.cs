using Godot;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class TrackAbility : PanelContainer
{
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
	[Export]
	public PackedScene TrackerContainerAbilityPackedScene { get; set; }
	[Export]
	public VBoxContainer TrackerContainer { get; set; }
	private AbilityManager AbilityManager { get; set; }
	private AbilityStats AbilityStats { get; set; }
	private Dictionary<string, TrackerContainerAbility> TrackerContainerDict { get; set; } = new();
	public override void _Ready()
	{
		base._Ready();
		this.AbilityManager = this.TrackingScreen.Viewer.AbilityManager;
		this.AbilityStats = AbilityStats.GetInstance();
		this.SetupAllTracker();
	}
	private void SetupAllTracker()
	{
		SetupTracker(Global.Element.Fire);
		SetupTracker(Global.Element.Water);
		SetupTracker(Global.Element.Wind);
		SetupTracker(Global.Element.Ice);
		SetupTracker(Global.Element.Electric);
		SetupTracker(Global.Element.Earth);
		SetupTracker(Global.Element.Wood);
		this.AbilityManager.StatusChanged += UpdateTracker;
	}
	private void SetupTracker(Global.Element element)
	{
		AbilityManager.AbilityStatus abilityStatus
			= this.AbilityManager.ElementStatus[element];
		int totalLevel = this.AbilityStats.ElementStats[element].Count;
		TrackerContainerAbility trackerContainerAbility
			= TrackerContainerAbilityPackedScene.Instantiate<TrackerContainerAbility>();
		trackerContainerAbility.Setup(abilityStatus, totalLevel, element);
		this.TrackerContainer.AddChild(trackerContainerAbility);
		this.TrackerContainerDict.Add(element.ToString(), trackerContainerAbility);
	}
	private void UpdateTracker(string element, bool maxLevel)
	{
		AbilityManager.AbilityStatus abilityStatus
			= this.AbilityManager.ElementStatus[this.AbilityStats.ElementDict[element]];
		TrackerContainerDict[element].Update(abilityStatus, maxLevel);
	}
	
}
