using Godot;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;
public partial class AbilityStats : Resource
{
	private static AbilityStats _instance;
	public static AbilityStats GetInstance()
	{
		if (_instance == null)
			_instance = new AbilityStats();
		return _instance;
	}
	private AbilityStats() : base()
	{
		FireStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 10 });
		FireStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 12 });
		FireStats.Add(2, new Record.AbilityInfo { ExpNeed = 175, Damage = 14 });
		FireStats.Add(3, new Record.AbilityInfo { ExpNeed = 250, Damage = 17 });
		FireStats.Add(4, new Record.AbilityInfo { ExpNeed = 325, Damage = 20 });
		FireStats.Add(5, new Record.AbilityInfo { ExpNeed = 425, Damage = 24 });
		FireStats.Add(6, new Record.AbilityInfo { ExpNeed = 550, Damage = 29 });
		FireStats.Add(7, new Record.AbilityInfo { ExpNeed = 700, Damage = 35 });
		FireStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 42 });

		WaterStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 10 });
		WaterStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 13 });
		WaterStats.Add(2, new Record.AbilityInfo { ExpNeed = 150, Damage = 16 });
		WaterStats.Add(3, new Record.AbilityInfo { ExpNeed = 225, Damage = 19 });
		WaterStats.Add(4, new Record.AbilityInfo { ExpNeed = 300, Damage = 22 });
		WaterStats.Add(5, new Record.AbilityInfo { ExpNeed = 400, Damage = 25 });
		WaterStats.Add(6, new Record.AbilityInfo { ExpNeed = 500, Damage = 28 });
		WaterStats.Add(7, new Record.AbilityInfo { ExpNeed = 600, Damage = 31 });
		WaterStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 34 });

		WindStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 7 });
		WindStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 9 });
		WindStats.Add(2, new Record.AbilityInfo { ExpNeed = 175, Damage = 11 });
		WindStats.Add(3, new Record.AbilityInfo { ExpNeed = 250, Damage = 13 });
		WindStats.Add(4, new Record.AbilityInfo { ExpNeed = 325, Damage = 16 });
		WindStats.Add(5, new Record.AbilityInfo { ExpNeed = 400, Damage = 19 });
		WindStats.Add(6, new Record.AbilityInfo { ExpNeed = 475, Damage = 22 });
		WindStats.Add(7, new Record.AbilityInfo { ExpNeed = 550, Damage = 25 });
		WindStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 28 });

		ElectricStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 12 });
		ElectricStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 16 });
		ElectricStats.Add(2, new Record.AbilityInfo { ExpNeed = 175, Damage = 20 });
		ElectricStats.Add(3, new Record.AbilityInfo { ExpNeed = 250, Damage = 24 });
		ElectricStats.Add(4, new Record.AbilityInfo { ExpNeed = 325, Damage = 28 });
		ElectricStats.Add(5, new Record.AbilityInfo { ExpNeed = 425, Damage = 32 });
		ElectricStats.Add(6, new Record.AbilityInfo { ExpNeed = 550, Damage = 36 });
		ElectricStats.Add(7, new Record.AbilityInfo { ExpNeed = 700, Damage = 40 });
		ElectricStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 44 });

		IceStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 7 });
		IceStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 10 });
		IceStats.Add(2, new Record.AbilityInfo { ExpNeed = 175, Damage = 13 });
		IceStats.Add(3, new Record.AbilityInfo { ExpNeed = 250, Damage = 16 });
		IceStats.Add(4, new Record.AbilityInfo { ExpNeed = 325, Damage = 19 });
		IceStats.Add(5, new Record.AbilityInfo { ExpNeed = 400, Damage = 23 });
		IceStats.Add(6, new Record.AbilityInfo { ExpNeed = 475, Damage = 27 });
		IceStats.Add(7, new Record.AbilityInfo { ExpNeed = 550, Damage = 31 });
		IceStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 35 });

		EarthStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 20 });
		EarthStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 22 });
		EarthStats.Add(2, new Record.AbilityInfo { ExpNeed = 150, Damage = 24 });
		EarthStats.Add(3, new Record.AbilityInfo { ExpNeed = 225, Damage = 26 });
		EarthStats.Add(4, new Record.AbilityInfo { ExpNeed = 300, Damage = 28 });
		EarthStats.Add(5, new Record.AbilityInfo { ExpNeed = 400, Damage = 30 });
		EarthStats.Add(6, new Record.AbilityInfo { ExpNeed = 525, Damage = 33 });
		EarthStats.Add(7, new Record.AbilityInfo { ExpNeed = 650, Damage = 36 });
		EarthStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 39 });

		WoodStats.Add(0, new Record.AbilityInfo { ExpNeed = 50, Damage = 25 });
		WoodStats.Add(1, new Record.AbilityInfo { ExpNeed = 100, Damage = 27 });
		WoodStats.Add(2, new Record.AbilityInfo { ExpNeed = 150, Damage = 29 });
		WoodStats.Add(3, new Record.AbilityInfo { ExpNeed = 225, Damage = 31 });
		WoodStats.Add(4, new Record.AbilityInfo { ExpNeed = 300, Damage = 34 });
		WoodStats.Add(5, new Record.AbilityInfo { ExpNeed = 400, Damage = 37 });
		WoodStats.Add(6, new Record.AbilityInfo { ExpNeed = 525, Damage = 40 });
		WoodStats.Add(7, new Record.AbilityInfo { ExpNeed = 650, Damage = 44 });
		WoodStats.Add(8, new Record.AbilityInfo { ExpNeed = 0, Damage = 48 });

		ElementStats.Add(Global.Element.Fire, FireStats);
		ElementStats.Add(Global.Element.Water, WaterStats);
		ElementStats.Add(Global.Element.Wind, WindStats);
		ElementStats.Add(Global.Element.Ice, IceStats);
		ElementStats.Add(Global.Element.Electric, ElectricStats);
		ElementStats.Add(Global.Element.Earth, EarthStats);
		ElementStats.Add(Global.Element.Wood, WoodStats);

		EnergyConsumption.Add(nameof(FireBall), 3);
		EnergyConsumption.Add(nameof(Ignite), 9);
		EnergyConsumption.Add(nameof(PenetratingSquirt), 2);
		EnergyConsumption.Add(nameof(TidalWave), 6);
		EnergyConsumption.Add(nameof(AirSurge), 2);
		EnergyConsumption.Add(nameof(Tornado), 7);
		EnergyConsumption.Add(nameof(Frostburn), 5);
		EnergyConsumption.Add(nameof(IceWall), 5);
		EnergyConsumption.Add(nameof(Lightning), 3);
		EnergyConsumption.Add(nameof(Overcharge), 7);
		EnergyConsumption.Add(nameof(SkyStrike), 7);
		//EnergyConsumption.Add(nameof(), 3); GolemGoGoGo ?
		EnergyConsumption.Add(nameof(RootTrap), 5);
		EnergyConsumption.Add(nameof(SereneMeadow), 14);

		ColorDict.Add(Global.Element.Fire, FireColor);
		ColorDict.Add(Global.Element.Water, WaterColor);
		ColorDict.Add(Global.Element.Wind, WindColor);
		ColorDict.Add(Global.Element.Ice, IceColor);
		ColorDict.Add(Global.Element.Electric, ElectricColor);
		ColorDict.Add(Global.Element.Earth, EarthColor);
		ColorDict.Add(Global.Element.Wood, WoodColor);
		ColorDict.Add(Global.Element.None, NoneColor);

		ElementDict.Add(Global.Element.Fire.ToString(), Global.Element.Fire);
		ElementDict.Add(Global.Element.Water.ToString(), Global.Element.Water);
		ElementDict.Add(Global.Element.Wind.ToString(), Global.Element.Wind);
		ElementDict.Add(Global.Element.Ice.ToString(), Global.Element.Ice);
		ElementDict.Add(Global.Element.Electric.ToString(), Global.Element.Electric);
		ElementDict.Add(Global.Element.Earth.ToString(), Global.Element.Earth);
		ElementDict.Add(Global.Element.Wood.ToString(), Global.Element.Wood);
	}
	public Dictionary<Global.Element, Dictionary<int, Record.AbilityInfo>> ElementStats
	{ get; private set; } = new();
	private Dictionary<int, Record.AbilityInfo> FireStats { get; set; } = new();
	private Dictionary<int, Record.AbilityInfo> WaterStats { get; set; } = new();
	private Dictionary<int, Record.AbilityInfo> WindStats { get; set; } = new();
	private Dictionary<int, Record.AbilityInfo> ElectricStats { get; set; } = new();
	private Dictionary<int, Record.AbilityInfo> IceStats { get; set; } = new();
	private Dictionary<int, Record.AbilityInfo> EarthStats { get; set; } = new();
	private Dictionary<int, Record.AbilityInfo> WoodStats { get; set; } = new();
	public Dictionary<string, int> EnergyConsumption { get; private set; } = new();
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
		public static float XSmall { get; private set; } = 0.5f;
		public static float Small { get; private set; } = 2.0f;
		public static float Medium { get; private set; } = 5.0f;
		public static float Large { get; private set; } = 8.0f;
		public static float XLarge { get; private set; } = 12.0f;
	}
	public Dictionary<Global.Element, Color> ColorDict { get; set; } = new();
	private Color FireColor { get; set; } = Helper.Color255ToColor1(255, 69, 0, 255);
	private Color WaterColor { get; set; } = Helper.Color255ToColor1(0, 97, 241, 255);
	private Color WindColor { get; set; } = Helper.Color255ToColor1(73, 233, 176, 255);
	private Color IceColor { get; set; } = Helper.Color255ToColor1(70, 216, 240, 255);
	private Color ElectricColor { get; set; } = Helper.Color255ToColor1(136, 31, 214, 255);
	private Color EarthColor { get; set; } = Helper.Color255ToColor1(226, 145, 45, 255);
	private Color WoodColor { get; set; } = Helper.Color255ToColor1(139, 69, 19, 255);
	private Color NoneColor { get; set; } = Helper.Color255ToColor1(255, 255, 255, 0);
	public Dictionary<string, Global.Element> ElementDict { get; set; } = new();
}
