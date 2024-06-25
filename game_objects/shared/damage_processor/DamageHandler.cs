using Godot;

namespace TokenTaleTheElementalSaga;

//CHAIN OF RESPONSIBILITY
#pragma warning disable IDE1006 // Naming Styles
public partial interface DamageHandler
#pragma warning restore IDE1006 // Naming Styles
{
    public void ProcessDamage(ref float damage);
}
