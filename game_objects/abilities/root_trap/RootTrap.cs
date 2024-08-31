using     Godot                    ;

namespace TokenTaleTheElementalSaga;

public partial class RootTrap : Ability3D
{
    public override void _Ready()
    {
                    base._Ready();
                    this.ActiveRange = AbilityStats.ActiveRange.Short;
                    this.DamageRatio =                           1.0f;
    }
}
