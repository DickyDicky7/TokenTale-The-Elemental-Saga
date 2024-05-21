using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class AbilityStats : Resource
{
	private AbilityStats() : base()
	{
		FireStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 10 });
		FireStats.Add(new Record.AbilityInfo { Level = 1, ExpNeed = 50, Damage = 12 });
		FireStats.Add(new Record.AbilityInfo { Level = 2, ExpNeed = 100, Damage = 14 });
		FireStats.Add(new Record.AbilityInfo { Level = 3, ExpNeed = 175, Damage = 17 });
		FireStats.Add(new Record.AbilityInfo { Level = 4, ExpNeed = 250, Damage = 20 });
		FireStats.Add(new Record.AbilityInfo { Level = 5, ExpNeed = 325, Damage = 24 });
		FireStats.Add(new Record.AbilityInfo { Level = 6, ExpNeed = 425, Damage = 29 });
		FireStats.Add(new Record.AbilityInfo { Level = 7, ExpNeed = 550, Damage = 35 });
		FireStats.Add(new Record.AbilityInfo { Level = 8, ExpNeed = 700, Damage = 42 });

		WaterStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 10 });
		WaterStats.Add(new Record.AbilityInfo { Level = 1, ExpNeed = 50, Damage = 13 });
		WaterStats.Add(new Record.AbilityInfo { Level = 2, ExpNeed = 100, Damage = 16 });
		WaterStats.Add(new Record.AbilityInfo { Level = 3, ExpNeed = 150, Damage = 19 });
		WaterStats.Add(new Record.AbilityInfo { Level = 4, ExpNeed = 225, Damage = 22 });
		WaterStats.Add(new Record.AbilityInfo { Level = 5, ExpNeed = 300, Damage = 25 });
		WaterStats.Add(new Record.AbilityInfo { Level = 6, ExpNeed = 400, Damage = 28 });
		WaterStats.Add(new Record.AbilityInfo { Level = 7, ExpNeed = 500, Damage = 31 });
		WaterStats.Add(new Record.AbilityInfo { Level = 8, ExpNeed = 600, Damage = 34 });

		WindStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 7 });
		WindStats.Add(new Record.AbilityInfo { Level = 1, ExpNeed = 50, Damage = 9 });
		WindStats.Add(new Record.AbilityInfo { Level = 2, ExpNeed = 100, Damage = 11 });
		WindStats.Add(new Record.AbilityInfo { Level = 3, ExpNeed = 175, Damage = 13 });
		WindStats.Add(new Record.AbilityInfo { Level = 4, ExpNeed = 250, Damage = 16 });
		WindStats.Add(new Record.AbilityInfo { Level = 5, ExpNeed = 325, Damage = 19 });
		WindStats.Add(new Record.AbilityInfo { Level = 6, ExpNeed = 400, Damage = 22 });
		WindStats.Add(new Record.AbilityInfo { Level = 7, ExpNeed = 475, Damage = 25 });
		WindStats.Add(new Record.AbilityInfo { Level = 8, ExpNeed = 550, Damage = 28 });

		ElectricStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 12 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 1, ExpNeed = 50, Damage = 16 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 2, ExpNeed = 100, Damage = 20 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 3, ExpNeed = 175, Damage = 24 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 4, ExpNeed = 250, Damage = 28 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 5, ExpNeed = 325, Damage = 32 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 6, ExpNeed = 425, Damage = 36 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 7, ExpNeed = 550, Damage = 40 });
		ElectricStats.Add(new Record.AbilityInfo { Level = 8, ExpNeed = 700, Damage = 44 });

		IceStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 7 });
		IceStats.Add(new Record.AbilityInfo { Level = 1, ExpNeed = 50, Damage = 10 });
		IceStats.Add(new Record.AbilityInfo { Level = 2, ExpNeed = 100, Damage = 13 });
		IceStats.Add(new Record.AbilityInfo { Level = 3, ExpNeed = 175, Damage = 16 });
		IceStats.Add(new Record.AbilityInfo { Level = 4, ExpNeed = 250, Damage = 19 });
		IceStats.Add(new Record.AbilityInfo { Level = 5, ExpNeed = 325, Damage = 23 });
		IceStats.Add(new Record.AbilityInfo { Level = 6, ExpNeed = 400, Damage = 27 });
		IceStats.Add(new Record.AbilityInfo { Level = 7, ExpNeed = 475, Damage = 31 });
		IceStats.Add(new Record.AbilityInfo { Level = 8, ExpNeed = 550, Damage = 35 });

		EarthStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 20 });
		EarthStats.Add(new Record.AbilityInfo { Level = 1, ExpNeed = 50, Damage = 22 });
		EarthStats.Add(new Record.AbilityInfo { Level = 2, ExpNeed = 100, Damage = 24 });
		EarthStats.Add(new Record.AbilityInfo { Level = 3, ExpNeed = 150, Damage = 26 });
		EarthStats.Add(new Record.AbilityInfo { Level = 4, ExpNeed = 225, Damage = 28 });
		EarthStats.Add(new Record.AbilityInfo { Level = 5, ExpNeed = 300, Damage = 30 });
		EarthStats.Add(new Record.AbilityInfo { Level = 6, ExpNeed = 400, Damage = 33 });
		EarthStats.Add(new Record.AbilityInfo { Level = 7, ExpNeed = 525, Damage = 36 });
		EarthStats.Add(new Record.AbilityInfo { Level = 8, ExpNeed = 650, Damage = 39 });

		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 0, Damage = 25 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 50, Damage = 27 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 100, Damage = 29 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 150, Damage = 31 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 225, Damage = 34 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 300, Damage = 37 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 400, Damage = 40 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 525, Damage = 44 });
		WoodStats.Add(new Record.AbilityInfo { Level = 0, ExpNeed = 650, Damage = 48 });
	}

	public static List<Record.AbilityInfo> FireStats { get; private set; }
	public static List<Record.AbilityInfo> WaterStats { get; private set; }
	public static List<Record.AbilityInfo> WindStats { get; private set; }
	public static List<Record.AbilityInfo> ElectricStats { get; private set; }
	public static List<Record.AbilityInfo> IceStats { get; private set; }
	public static List<Record.AbilityInfo> EarthStats { get; private set; }
	public static List<Record.AbilityInfo> WoodStats { get; private set; }
	public class ActiveRange
	{
		public static float Short { get; private set; } = 1.0f;
		public static float Medium { get; private set; } = 1.75f;
		public static float Long { get; private set; } = 2.5f;
		public static float Great { get; private set; } = 3.25f;
	}
	public class Speed
	{
		public static float Slow { get; private set; } = 0.5f;
		public static float Medium { get; private set; } = 1.0f;
		public static float MidFast { get; private set; } = 1.5f;
		public static float Fast { get; private set; } = 2.0f;
		public static float Quick { get; private set; } = 3.0f;
	}
	public class EffectRadius
	{
		public static float Small { get; private set; } = 0.5f;
		public static float Medium { get; private set; } = 0.8f;
		public static float Large { get; private set; } = 1.2f;
	}
}
