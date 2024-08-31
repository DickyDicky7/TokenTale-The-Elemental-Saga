using     Godot                    ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HealDrop : Item3D
{
    [ Export]
    public Area3D
           HitBox
    {
        get;
        set;
    }
    
    public override void _Ready()
    {
                    base._Ready();
        HitBox.BodyEntered +=
        HitBox_BodyEntered;
    }

    private void HitBox_BodyEntered(Node3D body)
    {
        if (body is MainCharacter
                    mainCharacter
           )
        {
            float    health = this.RandomizeAmouthOfHealth();
            float oldHealth =
                            mainCharacter.  @CurrentHealth  ;
            float newHealth = oldHealth +    health;
            float excessAmount = 0;
            if (newHealth > mainCharacter.MaxHealth)
            {
                excessAmount =                     (
                newHealth - mainCharacter.MaxHealth) * 0.7f;
                newHealth = mainCharacter.MaxHealth;
            }
            float    damage = oldHealth - newHealth;
            mainCharacter.CurrentHealth = newHealth;
            mainCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
            this.QueueFree();
            if (excessAmount > 0)
            {
                mainCharacter.EquipmentManager.StoreHealth(excessAmount);
            }
        }
    }

    private float RandomizeAmouthOfHealth()
    {
                  RandomNumberGenerator rand
            = new RandomNumberGenerator();
        return                          rand.RandfRange(15.0f, 25.0f);
    }
}
