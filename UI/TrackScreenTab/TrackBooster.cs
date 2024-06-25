using Godot;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace TokenTaleTheElementalSaga;
public partial class TrackBooster : PanelContainer
{
	[Export]
	public TrackingScreen TrackingScreen { get; set; }
	[Export]
	public TrackerContainerBooster HeartTracker { get; set; }
	[Export]
	public TrackerContainerBooster EnergyStoneTracker { get; set; }
	[Export]
	public TrackerContainerBooster SwordScrollTracker { get; set; }
	[Export]
	public TrackerContainerBooster BowScrollTracker { get; set; }
	[Export]
	public TrackerContainerBooster ElementalScrollTracker { get; set; }
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
		this.BoosterManager.HeartChanged += UpdateHeart;
		//energy stone
		EnergyStoneTracker.Setup(
			"ENERGY STONE",
			$"Max energy: {this.BoosterManager.MaxEnergy}",
			this.BoosterManager.EnergyStoneStatusList);
		this.BoosterManager.EnergyStoneChanged += UpdateEnergyStone;
		//sword scroll
		SwordScrollTracker.Setup(
			"SWORD SCROLL",
			$"Sword bonus damage ratio: {this.BoosterManager.SwordBonusDamageRatio}\n" + 
			$"Sword cooldown: {this.BoosterManager.SwordCoolDown}",
			this.BoosterManager.SwordScrollStatusList);
		this.BoosterManager.SwordSrcollChanged += UpdateSwordScroll;
		//bow scroll
		BowScrollTracker.Setup(
			"BOW SCROLL",
			$"Bow bonus damage ratio: {this.BoosterManager.BowBonusDamageRatio}\n" +
			$"Bow cooldown: {this.BoosterManager.BowCoolDown}",
			this.BoosterManager.BowScrollStatusList);
		this.BoosterManager.BowScrollChanged += UpdateBowScroll;
		//elemetnal scroll
		ElementalScrollTracker.Setup(
			"ELEMENTAL SCROLL",
			$"Elemental bonus damage ratio: {this.BoosterManager.ElementalBonusDamageRatio}\n" +
			$"Elemental cooldown: {this.BoosterManager.ElementalCoolDown}",
			this.BoosterManager.BowScrollStatusList);
		this.BoosterManager.ElementalScrollChanged += UpdateElementalScroll;
	}
	private void UpdateHeart(float newMaxHealth)
	{
		this.HeartTracker.Update(
			$"Max health: {this.BoosterManager.MaxHealth}",
			this.BoosterManager.HeartStatusList);
	}
	private void UpdateEnergyStone(int newMaxEnergy)
	{
		this.EnergyStoneTracker.Update(
			$"Max energy: {this.BoosterManager.MaxEnergy}",
			this.BoosterManager.EnergyStoneStatusList);
	}
	private void UpdateSwordScroll(float newSwordCoolDown, float newSwordBonusDamageRatio)
	{
		this.SwordScrollTracker.Update(
			$"Sword bonus damage ratio: {this.BoosterManager.SwordBonusDamageRatio}\n" +
			$"Sword cooldown: {this.BoosterManager.SwordCoolDown}",
			this.BoosterManager.SwordScrollStatusList);
	}
	private void UpdateBowScroll(float newBowCoolDown, float newBowBonusDamageRatio)
	{
		this.BowScrollTracker.Update(
			$"Bow bonus damage ratio: {this.BoosterManager.BowBonusDamageRatio}\n" +
			$"Bow cooldown: {this.BoosterManager.BowCoolDown}",
			this.BoosterManager.BowScrollStatusList);
	}
	private void UpdateElementalScroll(float newElementalCoolDown, float newElementalBonusDamageRatio)
	{
		this.ElementalScrollTracker.Update(
			$"Elemental bonus damage ratio: {this.BoosterManager.ElementalBonusDamageRatio}\n" +
			$"Elemental cooldown: {this.BoosterManager.ElementalCoolDown}",
			this.BoosterManager.ElementalScrollStatusList);
	}
}
