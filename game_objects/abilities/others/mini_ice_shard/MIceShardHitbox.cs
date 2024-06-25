using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class MIceShardHitbox : Hittbox3D
{
    private float SlowDuration { get; set; } = 3.0f;
    protected override void OnBodyEntered(Node3D node3D)
    {
        base.OnBodyEntered(node3D);
        if (this.GetParent() is Ability3D tempAbility)
        {
            if (node3D is MainCharacter tempMainCharacter)
                SlowDown(tempMainCharacter);
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
    private void SlowDown(MainCharacter mainCharacter)
    {
        mainCharacter.StartSpeedEffect(0.75f, this.SlowDuration);
    }
}
