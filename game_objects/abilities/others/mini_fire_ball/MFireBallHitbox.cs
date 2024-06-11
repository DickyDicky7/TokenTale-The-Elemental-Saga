using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class MFireBallHitbox : Hittbox3D
{
    protected override void OnBodyEntered(Node3D node3D)
    {
        base.OnBodyEntered(node3D);
        if (this.GetParent() is Ability3D tempAbility)
        {
            tempAbility.Stop();
            tempAbility.QueueFree();
        }
    }
    public override void _Ready()
    {
        base._Ready();
        this.EffectRadius = AbilityStats.EffectRadius.XSmall;
        this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
    }
}
