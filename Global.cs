using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Global : Node
{
    public enum Element
    {
        Fire    ,
        Water   ,
        Wind    ,
        Ice     ,
        Electric,
        Earth   ,
        Wood    ,
        None    ,
    }

    public enum  MonsterType
    {
         Distancer,
            Chaser,
        Teleporter,
         Supporter,
    }

    public enum ReactionType
    {
        Risk   ,
        Warning,
        Neutral,
        Buff   ,
    }
    public enum Difficulty
    {
        Beginner,
        Explorer,
        Survivor,
        Challenger
    }
}
