using Godot;

namespace TokenTaleTheElementalSaga;

//CHAIN OF RESPONSIBILITY
public partial class
           ElementalProficiencyDH
                         : BaseDH
{
    public float BonusDamageRatio
    {
                get;
        private set;
    }

    public ElementalProficiencyDH(float bonusDamageRatio)
    {
           this. BonusDamageRatio   =   bonusDamageRatio;
    }

    public override void     ProcessDamage(ref float damage)
    {
        damage += (damage * this.BonusDamageRatio);
        if (this.NextHandler is not null  )
                 NextHandler.ProcessDamage(ref       damage);
    }
}
