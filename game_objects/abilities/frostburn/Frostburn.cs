using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Frostburn : Ability3D
{
    public override void _Ready()
    {
        base._Ready();
        this.ActiveRange = AbilityStats.ActiveRange.Long;
        this.DamageRatio = 1.0f;
    }
}
