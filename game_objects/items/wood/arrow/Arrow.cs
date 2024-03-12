using Godot;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood  ;

public partial class Arrow : BaseWeapon
{
    public override void Wield()
    {
        throw new System.NotImplementedException();
    }

    public override void Reset()
    {
        throw new System.NotImplementedException();
    }


    #region Root -> Reset State
    private void OnResetStateEntered()
    {
        CollisionShape2DHitbox.SetDeferred("disabled", !false);
    }
    #endregion
}
