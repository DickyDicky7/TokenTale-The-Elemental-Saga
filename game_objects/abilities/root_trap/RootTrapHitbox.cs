using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class RootTrapHitbox : Hittbox3D
{
    protected override void OnBodyEntered(Node3D node3D)
    {
        base.OnBodyEntered(node3D);
        if (this.GetParent() is Ability3D tempAbility && node3D is Monster tempMonster)
        {
            if (tempMonster is ElementalMonster tempElementalMonster)
                if (tempElementalMonster.Element == Global.Element.Wood)
                    return;
            Trap(tempAbility, tempMonster);
        }
    }
    public override void _Ready()
    {
        base._Ready();
        this.EffectRadius = AbilityStats.EffectRadius.Small / 2;
        this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
    }
    private void Trap(Ability3D ability, Monster monster)
    {
        AnimationPlayer animationPlayer = ability.GetNode("AnimationPlayer") as AnimationPlayer;
        float timeLeft = (float)animationPlayer.CurrentAnimationLength
            - (float)animationPlayer.CurrentAnimationPosition;
        monster.StartSpeedEffect(0, timeLeft);
    }
}
