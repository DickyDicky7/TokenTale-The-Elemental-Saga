using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Skeleton : Monster
{
    public override void Attack(     MainCharacter targetMainCharacter)
    {
        float damage = this.CalculatePhysicsDamage(targetMainCharacter);
        targetMainCharacter.CurrentHealth -=Damage;
        targetMainCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
    }

    public override void AcceptVisitor(EnemiesVisitor visitor)
    {
        visitor.Visit(this);
    }

    public override
        void _Ready()
    {
        this.Key = "Undead";
        base._Ready()      ;
    }
}
