using Godot;

namespace TokenTaleTheElementalSaga;

//CHAIN OF RESPONSIBILITY
public partial class
           ElementalEquipmentDH
                       : BaseDH
{
    public float BonusDamage
    {
                get;
        private set;
    }

    public ElementalEquipmentDH(float bonusDamage)
    {
           this. BonusDamage    =     bonusDamage;
    }

    public override void     ProcessDamage(ref float damage)
    {
        damage += BonusDamage;
        if (this.NextHandler is not null  )
                 NextHandler.ProcessDamage(ref       damage);
    }
}
