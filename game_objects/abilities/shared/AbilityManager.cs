using Godot;
using System.Collections.Generic;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class AbilityManager : Node
{
	public record AbilityStatus
	{
		public Record.AbilityInfo AbilityInfo { get; set; }
		public int CurrentLevel { get; set; }
		public int CurrentExp { get; set; }
	}
	private AbilityStatus FireStatus { get; set; } = new();
	private AbilityStatus WaterStatus { get; set; } = new();
	private AbilityStatus WindStatus { get; set; } = new();
	private AbilityStatus IceStatus { get; set; } = new();
	private AbilityStatus ElectricStatus { get; set; } = new();
	private AbilityStatus EarthStatus { get; set; } = new();
	private AbilityStatus WoodStatus { get; set; } = new();
	public Dictionary<Global.Element, AbilityStatus> ElementStatus { get; private set; } = new();
	public AbilityManager()
	{
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
		}
	}
	public void UpdateStatus(Global.Element element, int exp)
	{
		ElementStatus[element].CurrentExp += exp;
		Update(ElementStatus[element], AbilityStats.GetInstance().ElementStats[element]);
	}
	private void Update(AbilityStatus abilityStatus, Dictionary<int, Record.AbilityInfo> stats)
	{
		if (abilityStatus.CurrentLevel == stats.Count - 1)
			return;
		else
		{
			Record.AbilityInfo AbilityInfo = stats[abilityStatus.CurrentLevel + 1];
			if (abilityStatus.CurrentExp >= AbilityInfo.ExpNeed)
			{
				abilityStatus.CurrentLevel += 1;
				abilityStatus.AbilityInfo = AbilityInfo;
			}
		}
	}
}
