using Godot;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class AbilityManager : Node
{
	[Signal]
	public delegate void StatusChangedEventHandler(string element, bool maxLevel);
	public record AbilityStatus
	{
		public Record.AbilityInfo AbilityInfo { get; set; }
		public int CurrentLevel { get; set; }
		public int CurrentExp { get; set; }
		public string ChosenAbility { get; set; }
	}
	private AbilityStatus FireStatus { get; set; } = new();
	private AbilityStatus WaterStatus { get; set; } = new();
	private AbilityStatus WindStatus { get; set; } = new();
	private AbilityStatus IceStatus { get; set; } = new();
	private AbilityStatus ElectricStatus { get; set; } = new();
	private AbilityStatus EarthStatus { get; set; } = new();
	private AbilityStatus WoodStatus { get; set; } = new();
	public Dictionary<Global.Element, AbilityStatus> ElementStatus { get; private set; } = new();
	public record AbilityKey
	{
		public Global.Element Element { get; set; }
		public int Key { get; set; }
	}
	public record AbilityUnlockInfo
	{
		public string AbilityName { get; set; }
		public bool Unlocked { get; set; }
	}
	public Dictionary<AbilityKey, AbilityUnlockInfo> AbilityList { get; private set; } = new();
	public AbilityManager()
	{
		InitAbilityList();

		ElementStatus.Add(Global.Element.Fire, FireStatus);
		ElementStatus.Add(Global.Element.Water, WaterStatus);
		ElementStatus.Add(Global.Element.Wind, WindStatus);
		ElementStatus.Add(Global.Element.Ice, IceStatus);
		ElementStatus.Add(Global.Element.Electric, ElectricStatus);
		ElementStatus.Add(Global.Element.Earth, EarthStatus);
		ElementStatus.Add(Global.Element.Wood, WoodStatus);

		foreach (Global.Element key in ElementStatus.Keys)
		{
			ElementStatus[key].AbilityInfo = AbilityStats.GetInstance().ElementStats[key][0];
			ElementStatus[key].CurrentExp = 0;
			ElementStatus[key].CurrentLevel = 0;
			ElementStatus[key].ChosenAbility = 
				AbilityList[new AbilityKey { Element = key, Key = 0 }].AbilityName;
		}
	}
	private void InitAbilityList()
	{
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Fire, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(FireBall), Unlocked = true });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Fire, Key = 1 },
			new AbilityUnlockInfo { AbilityName = nameof(Ignite), Unlocked = false });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Water, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(PenetratingSquirt), Unlocked = true });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Water, Key = 1 },
			new AbilityUnlockInfo { AbilityName = nameof(TidalWave), Unlocked = false });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Wind, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(AirSurge), Unlocked = true });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Wind, Key = 1 },
			new AbilityUnlockInfo { AbilityName = nameof(Tornado), Unlocked = false });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Ice, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(Frostburn), Unlocked = true });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Ice, Key = 1 },
			new AbilityUnlockInfo { AbilityName = nameof(IceWall), Unlocked = false });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Electric, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(Lightning), Unlocked = true });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Electric, Key = 1 },
			new AbilityUnlockInfo { AbilityName = nameof(Overcharge), Unlocked = false });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Earth, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(SkyStrike), Unlocked = true });
		//AbilityList.Add(
		//	new AbilityKey { Element = Global.Element.Earth, Key = 1 },
		//	nameof(Golem));
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Wood, Key = 0 },
			new AbilityUnlockInfo { AbilityName = nameof(RootTrap), Unlocked = true });
		AbilityList.Add(
			new AbilityKey { Element = Global.Element.Wood, Key = 1 },
			new AbilityUnlockInfo { AbilityName = nameof(SereneMeadow), Unlocked = false });
	}
	public void UpdateStatus(Global.Element element)
	{
		ElementStatus[element].CurrentExp +=
			AbilityStats.GetInstance().EnergyConsumption[ElementStatus[element].ChosenAbility];
		Update(
			ElementStatus[element], 
			AbilityStats.GetInstance().ElementStats[element],
			element);

	}
	private void Update(
		AbilityStatus abilityStatus,
		Dictionary<int, Record.AbilityInfo> stats,
		Global.Element element)
	{
		if (abilityStatus.CurrentLevel == stats.Count - 1)
			return;
		else
		{
			if (abilityStatus.CurrentExp >= abilityStatus.AbilityInfo.ExpNeed)
			{
				abilityStatus.CurrentLevel += 1;
				abilityStatus.AbilityInfo = stats[abilityStatus.CurrentLevel];
			}
			if (abilityStatus.CurrentLevel >= 5)
			{
				AbilityList[new AbilityKey { Element = element, Key = 1 }].Unlocked = true;
			}
			if (abilityStatus.CurrentLevel == stats.Count - 1)
				this.EmitSignal(AbilityManager.SignalName.StatusChanged, element.ToString(), true);
			else
				this.EmitSignal(AbilityManager.SignalName.StatusChanged, element.ToString(), false);

		}
	}
	public void ChooseAbility(Global.Element element, int key)
	{
		ElementStatus[element].ChosenAbility =
		AbilityList[new AbilityKey { Element = element, Key = 1 }].AbilityName;
	}
}
