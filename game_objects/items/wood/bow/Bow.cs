using Godot;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood  ;

public partial class Bow : BaseWeapon
{
    public override void Wield()
    {
        _stateChart.SendEvent("ToShootState");
    }

    public override void Reset()
    {
        _stateChart.SendEvent("ToResetState");
    }

    private void OnAnimationPlayerAnimationCease(StringName @animationName)
    {
        if (@animationName == "SHOOT")
        {
            EmitSignal(SignalName.OnWieldCease);
        }
    }


    #region Root -> Reset State
    private void OnResetStateEntered()
    {
        AnimationPlayer.Play("RESET");
        CollisionShape2DHitbox.SetDeferred("disabled", !false);
    }
    #endregion


    #region Root -> Shoot State
    private void OnShootStateEntered()
    {
        AnimationPlayer.Play("SHOOT");
        CollisionShape2DHitbox.SetDeferred("disabled", !false);
    }
    #endregion
}
