using Godot;
using System.Linq;

namespace TokenTaleTheElementalSaga;

[ GlobalClass ]
public abstract partial class ElementalMonster : Monster
{
    [  Export ]
    public Global.Element
                  Element
    {
        get; set;
    }
	private int[] FireRatioRange = { 50, 58, 66, 74, 82, 90, 98 };
	private int[] WaterRatioRange = { 8, 58, 66, 74, 82, 90, 98 };
	private int[] WindRatioRange = { 8, 16, 66, 74, 82, 90, 98 };
	private int[] IceRatioRange = { 8, 16, 24, 74, 82, 90, 98 };
	private int[] ElectricRatioRange = { 8, 16, 24, 32, 82, 90, 98 };
	private int[] EarthRatioRange = { 8, 16, 24, 32, 40, 90, 98 };
	private int[] WoodRatioRange = { 8, 16, 24, 32, 40, 48, 98 };
	private Godot.Collections.Dictionary<Global.Element, int[]> ElementRatioRange { get; set; } = new();
	protected override void SetupRatioRange()
	{
		string[] tempStrings = { "fire", "water", "wind", "ice", "electric", "earth", "wood" };
		int[] tempRatioRange = ElementRatioRange[this.Element];
		foreach(int i in Enumerable.Range(0, tempRatioRange.Length))
		{
			this.RatioRange.Add(tempRatioRange[i], tempStrings[i]);
		}
	}
	private void SetupRatioRangeTable()
	{
		ElementRatioRange.Add(Global.Element.Fire, FireRatioRange);
		ElementRatioRange.Add(Global.Element.Water, WaterRatioRange);
		ElementRatioRange.Add(Global.Element.Wind, WindRatioRange);
		ElementRatioRange.Add(Global.Element.Ice, IceRatioRange);
		ElementRatioRange.Add(Global.Element.Electric, ElectricRatioRange);
		ElementRatioRange.Add(Global.Element.Earth, EarthRatioRange);
		ElementRatioRange.Add(Global.Element.Wood, WoodRatioRange);
	}
	public override void _Ready()
	{
		this.SetupRatioRangeTable();
		base._Ready();
	}

}
