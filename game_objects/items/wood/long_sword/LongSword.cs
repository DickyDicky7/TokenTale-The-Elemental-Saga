using Godot;

using     TokenTaleTheElementalSaga.GameObjects.Items.Shared;
namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood  ;

public partial class LongSword : BaseWeapon
{
    public override void _Ready()
    {
        CollisionShape2DHitbox.SetDeferred("disabled", true);
    }

    public override void Wield()
    {
        _stateChart.SendEvent("ToSlashState");
    }

    public override void Reset()
    {
        _stateChart.SendEvent("ToResetState");
    }

    private void OnVisibilityChanged()
    {
        if (_stateChart != null)
        {
            _stateChart.SendEvent("ToResetState");
        }
    }

    private void OnAnimationPlayerAnimationCease(StringName @animationName)
    {
        if (@animationName == "SLASH")
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


    #region Root -> Slash State
    private void OnSlashStateEntered()
    {
        AnimationPlayer.Play("SLASH");
        CollisionShape2DHitbox.SetDeferred("disabled",  false);
    }
    #endregion
}
