using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Ghost : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {
		float damage = targetMainCharacter.BoosterManager.MaxHealth * 0.3f;
		targetMainCharacter.CurrentHealth -= Damage;
		targetMainCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
		targetMainCharacter.StatusInfo.Items.Add(
			new StatusInfoItemHurt { Thing = $"-{damage}🩸" });
        this.QueueFree();
    }
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitGhost(this);
	}
	public override void _Ready()
	{
		this.Key = "Haunt";
		base._Ready();
	}
}
