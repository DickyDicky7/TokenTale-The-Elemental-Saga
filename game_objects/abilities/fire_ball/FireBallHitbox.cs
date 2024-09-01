using     Godot                    ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class FireBallHitbox : Hittbox3D
{
    protected override void OnBodyEntered(Node3D node3D)
    {
        if (Hit == false)
            Explode();
                       base.OnBodyEntered(       node3D);
    }

    public override void _Ready()
    {
                    base._Ready();
        this.EffectRadius = AbilityStats.EffectRadius.XSmall;
        this.Scale        = new  Vector3(EffectRadius,
                                         EffectRadius,
                                         EffectRadius)      ;
    }

    private void Explode()
    {
        this.EffectRadius = AbilityStats.EffectRadius. Small;
        this.Scale        = new  Vector3(EffectRadius,
                                         EffectRadius,
                                         EffectRadius)      ;
        Ability3D  @temp  = this.GetParent()
    as  Ability3D               ;
        temp.DamageRatio  = 0.8f;
        temp.Stop       ()      ;
    }
}
