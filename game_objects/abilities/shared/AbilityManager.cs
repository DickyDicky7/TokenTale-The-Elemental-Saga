using Godot;
using System;
using System.Collections.Generic;
using System.Data;
namespace TokenTaleTheElementalSaga;
public partial class AbilityManager : Node
{
	public record AbilityStatus
	{
		public Record.AbilityInfo AbilityInfo { get; set; }
		public int CurrentExp { get; set; }
	}
	public AbilityStatus FireStatus { get; private set; } 
	public AbilityStatus WaterStatus { get; private set; } 
	public AbilityStatus WindStatus { get; private set; } 
	public AbilityStatus IceStatus { get; private set; } 
	public AbilityStatus ElectricStatus { get; private set; } 
	public AbilityStatus EarthStatus { get; private set; } 
	public AbilityStatus WoodStatus { get; private set; } 
	public AbilityManager()
	{
		FireStatus = new AbilityStatus { AbilityInfo = AbilityStats.FireStats[0], CurrentExp = 0 };
		WaterStatus = new AbilityStatus { AbilityInfo = AbilityStats.WaterStats[0], CurrentExp = 0 };
		WindStatus = new AbilityStatus { AbilityInfo = AbilityStats.WindStats[0], CurrentExp = 0 };
		IceStatus = new AbilityStatus { AbilityInfo = AbilityStats.IceStats[0], CurrentExp = 0 };
		ElectricStatus = new AbilityStatus { AbilityInfo = AbilityStats.ElectricStats[0], CurrentExp = 0 };
		EarthStatus = new AbilityStatus { AbilityInfo = AbilityStats.EarthStats[0], CurrentExp = 0 };
		WoodStatus = new AbilityStatus { AbilityInfo = AbilityStats.WoodStats[0], CurrentExp = 0 };
	}
	public void UpdateStatus(Global.Element Element, int Exp)
	{
		switch (Element)
		{
			case Global.Element.Fire:
				FireStatus.CurrentExp += Exp;
				Update(FireStatus, AbilityStats.FireStats);
				break;
			case Global.Element.Water:
				WaterStatus.CurrentExp += Exp;
				Update(WaterStatus, AbilityStats.WaterStats);
				break;
			case Global.Element.Wind:
				WindStatus.CurrentExp += Exp;
				Update(WindStatus, AbilityStats.WindStats);
				break;
			case Global.Element.Ice:
				IceStatus.CurrentExp += Exp;
				Update(IceStatus, AbilityStats.IceStats);
				break;
			case Global.Element.Electric:
				ElectricStatus.CurrentExp += Exp;
				Update(ElectricStatus, AbilityStats.ElectricStats);
				break;
			case Global.Element.Earth:
				EarthStatus.CurrentExp += Exp;
				Update(EarthStatus, AbilityStats.EarthStats);
				break;
			case Global.Element.Wood:
				WoodStatus.CurrentExp += Exp;
				Update(WoodStatus, AbilityStats.WoodStats);
				break;
		}
	}
	private void Update(AbilityStatus AbilityStatus, List<Record.AbilityInfo> Stats)
	{
		if (AbilityStatus.AbilityInfo.Level == Stats.Count - 1)
			return;
		else
		{
			Record.AbilityInfo temp = Stats
				.Find(x => x.Level == AbilityStatus.AbilityInfo.Level + 1);
			if (AbilityStatus.CurrentExp >= temp.ExpNeed)
				AbilityStatus.AbilityInfo = temp;
		}
	}
}
