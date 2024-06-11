using Godot;

namespace TokenTaleTheElementalSaga;

public partial class
           BowProficiencyDH
                   : BaseDH
{
    public float BonusDamageRatio { get; private set; }
    
    public BowProficiencyDH(float bonusDamageRatio)
    {
           this. BonusDamageRatio=bonusDamageRatio;
    }
    
    public override void     ProcessDamage(ref float damage)
    {
        damage += (damage * this.BonusDamageRatio);
        if (this.NextHandler is not null  )
                 NextHandler.ProcessDamage(ref       damage);
    }
}
