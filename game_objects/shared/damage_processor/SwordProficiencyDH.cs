using Godot;

namespace TokenTaleTheElementalSaga;

public partial class
           SwordProficiencyDH
                     : BaseDH
{
    public float BonusDamageRatio
    {
                get;
        private set;
    }

    public SwordProficiencyDH    (
           float bonusDamageRatio)
    {
            this.BonusDamageRatio =
                 bonusDamageRatio ;
    }

    public override void     ProcessDamage(ref float damage)
    {
        damage += (damage * this.BonusDamageRatio);
        if (this.NextHandler is not null  )
                 NextHandler.ProcessDamage(ref       damage);
    }
}
