using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class MBlowWindHitbox : Hittbox3D
{
    public float PushSpeed { get; private set; } = AbilityStats.Speed.MidFast;
    protected override void OnBodyEntered(Node3D node3D)
    {
        base.OnBodyEntered(node3D);
        if (this.GetParent() is Ability3D tempAbility)
        {
            if (node3D is MainCharacter tempMainCharacter)
                PushMainCharacterAside(tempAbility, tempMainCharacter);
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
    private void PushMainCharacterAside(Ability3D ability, MainCharacter mainCharacter)
    {
        Vector3 pushDirection = ability.GlobalPosition.DirectionTo(mainCharacter.GlobalPosition);
        pushDirection = new Vector3(pushDirection.X, 0, pushDirection.Z).Normalized();
        mainCharacter.BePushed(pushDirection * PushSpeed * 10);
    }
}
