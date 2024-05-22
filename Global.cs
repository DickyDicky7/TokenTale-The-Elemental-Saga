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
}
