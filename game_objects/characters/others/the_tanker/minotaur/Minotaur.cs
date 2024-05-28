using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Minotaur : Monster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {
		float damage = this.CurrentDamage;
		targetMainCharacter.CurrentHealth -= Damage;
		targetMainCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
		targetMainCharacter.StatusInfo.Items.Add(
			new StatusInfoItemHurt { Thing = $"-{damage}🩸" });
	}
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitMinotaur(this);
	}
	public override void _Ready()
	{
		this.Key = "Tanker";
		base._Ready();
	}
}
