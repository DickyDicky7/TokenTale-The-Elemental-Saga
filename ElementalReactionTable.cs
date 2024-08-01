using Godot ;
using System;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public partial class ElementalReactionTable : Resource
{
    private static ElementalReactionTable    _instance  ;
    public  static ElementalReactionTable  GetInstance()
    {
        if (   _instance == null   )
               _instance =  new ElementalReactionTable();
        return _instance;
    }

    private ElementalReactionTable() : base()
    {
        FireReaction.Add(Global.ReactionType.Risk);
        FireReaction.Add(Global.ReactionType.Buff);
        FireReaction.Add(Global.ReactionType.Buff);
        FireReaction.Add(Global.ReactionType.Warning);
        FireReaction.Add(Global.ReactionType.Buff);
        FireReaction.Add(Global.ReactionType.Neutral);
        FireReaction.Add(Global.ReactionType.Risk);

        WaterReaction.Add(Global.ReactionType.Warning);
        WaterReaction.Add(Global.ReactionType.Risk);
        WaterReaction.Add(Global.ReactionType.Neutral);
        WaterReaction.Add(Global.ReactionType.Warning);
        WaterReaction.Add(Global.ReactionType.Buff);
        WaterReaction.Add(Global.ReactionType.Neutral);
        WaterReaction.Add(Global.ReactionType.Neutral);

        WindReaction.Add(Global.ReactionType.Buff);
        WindReaction.Add(Global.ReactionType.Buff);
        WindReaction.Add(Global.ReactionType.Risk);
        WindReaction.Add(Global.ReactionType.Neutral);
        WindReaction.Add(Global.ReactionType.Neutral);
        WindReaction.Add(Global.ReactionType.Neutral);
        WindReaction.Add(Global.ReactionType.Neutral);

        IceReaction.Add(Global.ReactionType.Buff);
        IceReaction.Add(Global.ReactionType.Warning);
        IceReaction.Add(Global.ReactionType.Neutral);
        IceReaction.Add(Global.ReactionType.Risk);
        IceReaction.Add(Global.ReactionType.Buff);
        IceReaction.Add(Global.ReactionType.Buff);
        IceReaction.Add(Global.ReactionType.Neutral);

        ElectricReaction.Add(Global.ReactionType.Buff);
        ElectricReaction.Add(Global.ReactionType.Buff);
        ElectricReaction.Add(Global.ReactionType.Neutral);
        ElectricReaction.Add(Global.ReactionType.Neutral);
        ElectricReaction.Add(Global.ReactionType.Risk);
        ElectricReaction.Add(Global.ReactionType.Neutral);
        ElectricReaction.Add(Global.ReactionType.Neutral);

        EarthReaction.Add(Global.ReactionType.Neutral);
        EarthReaction.Add(Global.ReactionType.Warning);
        EarthReaction.Add(Global.ReactionType.Warning);
        EarthReaction.Add(Global.ReactionType.Neutral);
        EarthReaction.Add(Global.ReactionType.Neutral);
        EarthReaction.Add(Global.ReactionType.Risk);
        EarthReaction.Add(Global.ReactionType.Buff);

        WoodReaction.Add(Global.ReactionType.Buff);
        WoodReaction.Add(Global.ReactionType.Risk);
        WoodReaction.Add(Global.ReactionType.Warning);
        WoodReaction.Add(Global.ReactionType.Buff);
        WoodReaction.Add(Global.ReactionType.Neutral);
        WoodReaction.Add(Global.ReactionType.Buff);
        WoodReaction.Add(Global.ReactionType.Risk);

        ReactionTable.Add(   @FireReaction);
        ReactionTable.Add(   WaterReaction);
        ReactionTable.Add(   @WindReaction);
        ReactionTable.Add(     IceReaction);
        ReactionTable.Add(ElectricReaction);
        ReactionTable.Add(   EarthReaction);
        ReactionTable.Add(   @WoodReaction);
    }
    public  List<List<Global.ReactionType>> ReactionTable { get; set; } = new();
    private List<Global.ReactionType>    @FireReaction { get; set; } = new();
    private List<Global.ReactionType>    WaterReaction { get; set; } = new();
    private List<Global.ReactionType>    @WindReaction { get; set; } = new();
    private List<Global.ReactionType>      IceReaction { get; set; } = new();
    private List<Global.ReactionType> ElectricReaction { get; set; } = new();
    private List<Global.ReactionType>    EarthReaction { get; set; } = new();
    private List<Global.ReactionType>    @WoodReaction { get; set; } = new();
}
