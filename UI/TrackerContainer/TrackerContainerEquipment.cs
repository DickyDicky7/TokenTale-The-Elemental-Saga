using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class TrackerContainerEquipment : VBoxContainer
{
	[Export]
	public Label Title { get; set; }
	[Export]
	public HBoxContainer TrackUnitContainer { get; set; }
	[Export]
	public HBoxContainer TrackLevelContainer { get; set; }
	[Export]
	public Label Prop { get; set; }
	[Export]
	public Button UpgradeButton { get; set; }
	private Equipment Partner { get; set; }
	private Timer Timer { get; set; } = new();
	private Color CheckedColor = Helper.Color255ToColor1(47, 255, 67, 255);
	private Color UncheckedColor = Helper.Color255ToColor1(128, 128, 128, 255);
	private Color WarningColor = Helper.Color255ToColor1(204, 51, 0, 255);
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
	private void SetupTimer()
	{
		this.Timer.ProcessCallback = Timer.TimerProcessCallback.Physics;
		this.Timer.OneShot = true;
		this.Timer.Timeout += EndTimer;
		this.AddChild(Timer);
	}
	private void StartTimer()
	{
		Timer.Start(1);
		this.UpgradeButton.SelfModulate = WarningColor;
		this.UpgradeButton.Text = $"Need {this.Partner.NextLevelUpgradeCost} coin!";
	}
	private void EndTimer()
	{
		Timer.Stop();
		this.UpgradeButton.SelfModulate = Helper.Color255ToColor1(255, 255, 255, 255);
		this.UpgradeButton.Text = "Upgrade";
	}
	public void Setup(string title, string prop, int totalLevel, Equipment equipment)
	{
		foreach (int i in Enumerable.Range(0, totalLevel))
		{
			ColorRect colorRect = SetupColorRect(i <= equipment.Level);
			this.TrackUnitContainer.AddChild(colorRect);

			Label label = SetupLabel(i + 1);
			this.TrackLevelContainer.AddChild(label);
		}
		this.Title.Text = title;
		this.Prop.Text = prop;
		this.Partner = equipment;
		this.Partner.JustUpgrade += Update;
		this.UpgradeButton.Pressed += UpgradePartner;
		this.SetupTimer();
		if (Partner.Available is false)
		{
			this.UpgradeButton.Disabled = true;
			this.UpgradeButton.Text = "Not available";
		}
	}
	public void Update()
	{
		Godot.Collections.Array<Node> TrackUnits = this.TrackUnitContainer.GetChildren();
		foreach (int i in Enumerable.Range(0, TrackUnits.Count))
		{
			if (TrackUnits[i] is ColorRect colorRect && i <= this.Partner.Level)
			{
				colorRect.SelfModulate = CheckedColor;
			}
		}
		if (this.Partner is Sword sword)
			this.Prop.Text = $"Damage: {sword.Damage}";
		else if (this.Partner is _Bow_ bow)
			this.Prop.Text = $"Damage: {bow.Damage}";
		else if (this.Partner is ElementalBracelet bracelet)
			this.Prop.Text = $"Bonus damage: {bracelet.BonusDamage}";
		else if (this.Partner is Boot boot)
			this.Prop.Text = $"Speed: {boot.Speed}";
		else if (this.Partner is Quiver quiver)
			this.Prop.Text = $"Max arrow: {quiver.MaxArrow}";
		else if (this.Partner is PowerupsGenerator powerupsGenerator)
			this.Prop.Text = $"Max stored uses: {powerupsGenerator.MaxUses}";
		if (this.Partner.Available is true)
		{
			this.UpgradeButton.Text = "Upgrade";
			this.UpgradeButton.Disabled = false;
		}
	}
	private void UpgradePartner()
	{
		if (Partner.NextLevelUpgradeCost <= this.Partner.OwnerMainCharacter.CurrentCoin)
		{
			this.Partner.OwnerMainCharacter.CurrentCoin -= Partner.NextLevelUpgradeCost;
			this.Partner.Upgrade();
			this.Partner.OwnerMainCharacter.EmitSignal(
				MainCharacter.SignalName.CoinChanged,
				this.Partner.OwnerMainCharacter.CurrentCoin);
			if (this.Partner.Upgradeable is false)
			{
				this.UpgradeButton.Text = "Max level";
				this.UpgradeButton.Disabled = true;
			}
		}
		else
		{
			this.StartTimer();
		}
	}
}
