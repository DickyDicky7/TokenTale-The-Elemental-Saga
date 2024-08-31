using @Godot;
using System;
using static TokenTaleTheElementalSaga.AbilityStats;

namespace    TokenTaleTheElementalSaga             ;

public partial class LightningHitbox : Hittbox3D
{
    private float
    @StunDuration
    {
        get;
        set;
    } = 1.0f;
    
    protected override void OnBodyEntered(Node3D node3D)
    {
                       base.OnBodyEntered(       node3D);

        if (Helper.SuccessBaseOnRate(0.15f)
        &&  node3D
        is  Monster
        tempMonster)
        {
            if (tempMonster is ElementalMonster
                           tempElementalMonster   )
            {
                if (tempElementalMonster.Element
                is                Global.Element.Electric)
                    return;
            }
                tempMonster.StartStun(StunDuration);
        }
    }

    public override void _Ready()
    {
                    base._Ready();
                    this.EffectRadius = AbilityStats.EffectRadius.Small;
                    this.Scale        = new  Vector3(EffectRadius,
                                                     EffectRadius,
                                                     EffectRadius)     ;
    }
}
