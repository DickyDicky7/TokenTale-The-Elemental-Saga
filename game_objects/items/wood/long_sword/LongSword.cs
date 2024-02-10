using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Items.Wood;

public partial class LongSword : Area2D
{
    private AnimationPlayer _animationPlayer;

    public override void _Ready()
    {
        _animationPlayer = GetNode<AnimationPlayer>(nameof(AnimationPlayer));
    }

    public virtual void Slash()
    {
        _animationPlayer.Play("SLASH");
    }

    public virtual void Reset()
    {
        _animationPlayer.Play("RESET");
    }
}
