using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Monster : Character3D
{
    [Export]
    public Global.MonsterType MonsterType { get; set; }
    public abstract void Attack(Character3D target);
}
