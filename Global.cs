using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

public partial class Global : Node
{
    public enum Element
    {
        Fire,
        Water,
        Wind,
        Ice,
        Eletric,
        Rock,
        Wood
    }
    public enum MonsterType
    {
        Distancer,
        Chaser,
        Teleporter,
        Supporter
    }
}
