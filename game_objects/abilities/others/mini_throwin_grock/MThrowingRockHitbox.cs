using Godot;
using System;
using System.Linq;
namespace TokenTaleTheElementalSaga;
public partial class MThrowingRockHitbox : Hittbox3D
{
    private bool HitStaticBody { get; set; } = false;
    protected override void OnBodyEntered(Node3D node3D)
    {
        if (node3D is StaticBody3D && this.HitStaticBody == false)
        {
            this.HitStaticBody = true;
            return;
        }
        if (this.GetParent() is Ability3D tempAbility)
        {
            AnimationPlayer tempAnimationPlayer = tempAbility
                .GetNode("AnimationPlayer") as AnimationPlayer;
            tempAnimationPlayer.Play("HIT");
        }
        base.OnBodyEntered(node3D);
    }
    public override void _Ready()
    {
        base._Ready();
        this.EffectRadius = AbilityStats.EffectRadius.Small;
        this.Scale = new Vector3(EffectRadius, EffectRadius, EffectRadius);
    }
}
