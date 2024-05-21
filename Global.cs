using Godot;
using Godot.Collections;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public partial class Global : Node
{
    public enum Element
    {
        Fire,
        Water,
        Wind,
        Ice,
        Electric,
        Earth,
        Wood,
		None
    }
    public enum MonsterType
    {
        Distancer,
        Chaser,
        Teleporter,
        Supporter
    }
	public enum ReactionType
	{
		Risk,
		Warning,
		Neutral,
		Buff
	}
	public override void _Ready()
	{
		base._Ready();
        FireReaction.Add(ReactionType.Risk);
        FireReaction.Add(ReactionType.Buff);
		FireReaction.Add(ReactionType.Buff);
		FireReaction.Add(ReactionType.Warning);
		FireReaction.Add(ReactionType.Buff);
		FireReaction.Add(ReactionType.Neutral);
		FireReaction.Add(ReactionType.Risk);

		WaterReaction.Add(ReactionType.Warning);
		WaterReaction.Add(ReactionType.Risk);
		WaterReaction.Add(ReactionType.Neutral);
		WaterReaction.Add(ReactionType.Warning);
		WaterReaction.Add(ReactionType.Buff);
		WaterReaction.Add(ReactionType.Neutral);
		WaterReaction.Add(ReactionType.Neutral);

		WindReaction.Add(ReactionType.Buff);
		WindReaction.Add(ReactionType.Buff);
		WindReaction.Add(ReactionType.Risk);
		WindReaction.Add(ReactionType.Neutral);
		WindReaction.Add(ReactionType.Neutral);
		WindReaction.Add(ReactionType.Neutral);
		WindReaction.Add(ReactionType.Neutral);

		IceReaction.Add(ReactionType.Buff);
		IceReaction.Add(ReactionType.Warning);
		IceReaction.Add(ReactionType.Neutral);
		IceReaction.Add(ReactionType.Risk);
		IceReaction.Add(ReactionType.Buff);
		IceReaction.Add(ReactionType.Buff);
		IceReaction.Add(ReactionType.Neutral);

		ElectricReaction.Add(ReactionType.Buff);
		ElectricReaction.Add(ReactionType.Buff);
		ElectricReaction.Add(ReactionType.Neutral);
		ElectricReaction.Add(ReactionType.Neutral);
		ElectricReaction.Add(ReactionType.Risk);
		ElectricReaction.Add(ReactionType.Neutral);
		ElectricReaction.Add(ReactionType.Neutral);

		EarthReaction.Add(ReactionType.Neutral);
		EarthReaction.Add(ReactionType.Warning);
		EarthReaction.Add(ReactionType.Warning);
		EarthReaction.Add(ReactionType.Neutral);
		EarthReaction.Add(ReactionType.Neutral);
		EarthReaction.Add(ReactionType.Risk);
		EarthReaction.Add(ReactionType.Buff);

		WoodReaction.Add(ReactionType.Buff);
		WoodReaction.Add(ReactionType.Risk);
		WoodReaction.Add(ReactionType.Warning);
		WoodReaction.Add(ReactionType.Buff);
		WoodReaction.Add(ReactionType.Neutral);
		WoodReaction.Add(ReactionType.Buff);
		WoodReaction.Add(ReactionType.Risk);

		ReactionTable.Add(FireReaction);
		ReactionTable.Add(WaterReaction);
		ReactionTable.Add(WindReaction);
		ReactionTable.Add(IceReaction);
		ReactionTable.Add(ElectricReaction);
		ReactionTable.Add(EarthReaction);
		ReactionTable.Add(WoodReaction);
	}
	public static List<List<Global.ReactionType>> ReactionTable { get; set; }
    private List<ReactionType> FireReaction { get; set; }
	private List<ReactionType> WaterReaction { get; set; }
	private List<ReactionType> WindReaction { get; set; }
	private List<ReactionType> IceReaction { get; set; }
	private List<ReactionType> ElectricReaction { get; set; }
	private List<ReactionType> EarthReaction { get; set; }
	private List<ReactionType> WoodReaction { get; set; }

}
