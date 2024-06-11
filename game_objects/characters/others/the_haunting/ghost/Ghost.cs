using Godot ;
using System;

namespace TokenTaleTheElementalSaga;

public partial class Ghost : Monster
{
    public override void Attack           (
                             MainCharacter
                       targetMainCharacter)
    {
        float damage = targetMainCharacter  .  BoosterManager.MaxHealth   *  0.3f  ;
              damage = (float)Math.Round(damage, 2);
        targetMainCharacter.CurrentHealth -= Damage;
        targetMainCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
        targetMainCharacter.StatusInfo.Items.Add(
              new StatusInfoItemHurt { Thing = $"-{damage}🩸" });
        this.QueueFree();
    }
    
    public override void AcceptVisitor(EnemiesVisitor visitor)
    {
        visitor.Visit(this);
    }

    public override
        void _Ready()
    {
        this.Key = "Haunt";
        base._Ready()     ;
    }
}
