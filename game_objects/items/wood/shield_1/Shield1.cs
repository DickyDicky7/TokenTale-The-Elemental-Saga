using Godot;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood  ;

public partial class Shield1 : BaseWeapon
{
    public override void Wield()
    {
        _stateChart.SendEvent("ToGuardState");
    }

    public override void Reset()
    {
        _stateChart.SendEvent("ToResetState");
    }

    private void OnAnimationPlayerAnimationCease(StringName @animationName)
    {
        if (@animationName == "GUARD")
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


    #region Root -> Guard State
    private void OnGuardStateEntered()
    {
        AnimationPlayer.Play("GUARD");
        CollisionShape2DHitbox.SetDeferred("disabled",  false);
    }
    #endregion
}
