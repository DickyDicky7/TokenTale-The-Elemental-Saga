using Godot;

namespace TokenTaleTheElementalSaga;

public partial class SkyStrike : Ability3D
{
    public override void _Ready()
    {
        base._Ready();
        this.ActiveRange = AbilityStats.ActiveRange.Medium;
        this.DamageRatio = 1.0f;
    }
}
