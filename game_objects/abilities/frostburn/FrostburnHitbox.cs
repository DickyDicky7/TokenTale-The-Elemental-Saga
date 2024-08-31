using @Godot;
using System;

namespace TokenTaleTheElementalSaga;

public partial class FrostburnHitbox : Hittbox3D
{
    public float SlowDuration
    {
                get;
        private set;
    } = 2.0f;
    
    protected override void OnBodyEntered(Node3D node3D)
    {
                       base.OnBodyEntered(       node3D);

        if (node3D
        is  Monster
        tempMonster
            )
        {
            if (tempMonster is ElementalMonster
                            @tempElementMonster)
            {
                if (         tempElementMonster.Element == Global.Element.Ice)
                    return;
                else
                    SlowDown(tempElementMonster);
            }
            else
            {
                    SlowDown(       tempMonster);
            }
        }
    }

    public override void _Ready()
    {
                    base._Ready();
                    this.EffectRadius =
            AbilityStats.EffectRadius.Small;
                    this.Scale = new Vector3(EffectRadius,
                                             EffectRadius,
                                             EffectRadius);
    }

    public void SlowDown(Monster monster)
    {
        monster.StartSpeedEffect(0.5f, this.SlowDuration);
    }
}
