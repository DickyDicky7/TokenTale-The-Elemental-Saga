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
	private BoosterManager BoosterManager { get; set; }
	public override void _Ready()
	{
		base._Ready();
		this.BoosterManager = this.TrackingScreen.Viewer.BoosterManager;
		this.SetupAllTracker();
	}
	private void SetupAllTracker()
	{
		//heart
		HeartTracker.Setup(
			"HEART",
			$"Max health: {this.BoosterManager.MaxHealth}",
			this.BoosterManager.HeartStatusList);
		//energy stone
		EnergyStoneTracker.Setup(
			"ENERGY STONE",
			$"Max energy: {this.BoosterManager.MaxEnergy}",
			this.BoosterManager.EnergyStoneStatusList);
		//sword scroll
		SwordScrollTracker.Setup(
			"SWORD SCROLL",
			$"Sword bonus damage ratio: {this.BoosterManager.SwordBonusDamageRatio}\n" + 
			$"Sword cooldown: {this.BoosterManager.SwordCoolDown}",
			this.BoosterManager.SwordScrollStatusList);
		//bow scroll
		BowScrollTracker.Setup(
			"BOW SCROLL",
			$"Bow bonus damage ratio: {this.BoosterManager.BowBonusDamageRatio}\n" +
			$"Bow cooldown: {this.BoosterManager.BowCoolDown}",
			this.BoosterManager.BowScrollStatusList);
		//elemetnal scroll
		ElementalScrollTracker.Setup(
			"ELEMENTAL SCROLL",
			$"Elemental bonus damage ratio: {this.BoosterManager.ElementalBonusDamageRatio}\n" +
			$"Elemental cooldown: {this.BoosterManager.ElementalCoolDown}",
			this.BoosterManager.BowScrollStatusList);
	}
}
