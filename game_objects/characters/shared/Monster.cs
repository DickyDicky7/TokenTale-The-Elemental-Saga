using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Monster : Character3D
{
    [Export]
    public Global.MonsterType MonsterType { get; set; }
    [Export] 
    public float MaxHealth { get; set; }
    public Global.Element ElementMark { get; set; }
    public abstract void Attack(Character3D target);
	public override void _Ready()
	{
		base._Ready();
        this.CurrentHealth = MaxHealth;
	}
}
