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
	private int[] FireRatioRange = { 38, 44, 50, 56, 62, 68, 74, 100 };
	private int[] WaterRatioRange = { 6, 44, 50, 56, 62, 68, 74, 100 };
	private int[] WindRatioRange = { 6, 12, 50, 56, 62, 68, 74, 100 };
	private int[] IceRatioRange = { 6, 12, 18, 56, 62, 68, 74, 100 };
	private int[] ElectricRatioRange = { 6, 12, 18, 24, 62, 68, 74, 100 };
	private int[] EarthRatioRange = { 6, 12, 18, 24, 30, 68, 74, 100 };
	private int[] WoodRatioRange = { 6, 12, 18, 24, 30, 36, 74, 100 };
	private Godot.Collections.Dictionary<Global.Element, int[]> ElementRatioRange { get; set; } = new();
	protected override void SetupRatioRange()
	{
		string[] tempStrings = { "fire", "water", "wind", "ice", "electric", "earth", "wood", "heal" };
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
