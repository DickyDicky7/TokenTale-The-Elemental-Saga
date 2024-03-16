using Godot;

namespace TokenTaleTheElementalSaga;

public partial class State_Bow_Shoot : State_Bow_
{
    [Export]
    [ExportGroup("Transition ##")]
    public State ResetState {  get; set; }

    public override void _Enter()
    {
                    base._Enter();

        _Bow_.IsInUse = true;
        _Bow_.AnimatedSprite2D__Main.Play("SHOOT");
        _Bow_.CollisionShape2D      .SetDeferred("disabled", true);
        _Bow_.AnimatedSprite2D__Main.AnimationFinished += AnimatedSprite2D__Main_AnimationFinished; ;
        _Bow_.AnimatedSprite2DEffect.AnimationFinished += AnimatedSprite2DEffect_AnimationFinished;
    }

    public override void _Leave()
    {
                    base._Leave();

        _Bow_.AnimatedSprite2D__Main.AnimationFinished -= AnimatedSprite2D__Main_AnimationFinished; ;
        _Bow_.AnimatedSprite2DEffect.AnimationFinished -= AnimatedSprite2DEffect_AnimationFinished;
    }

    private void AnimatedSprite2D__Main_AnimationFinished()
    {
        if (_Bow_
                .AnimatedSprite2D__Main.Animation == "SHOOT")
        {
            _Bow_
                .AnimatedSprite2DEffect
                .Play("SHOOT");
        }
    }

    private void AnimatedSprite2DEffect_AnimationFinished()
    {
        if (_Bow_
                .AnimatedSprite2DEffect.Animation == "SHOOT")
        {
            _Bow_
                .AnimatedSprite2DEffect
                .Play("RESET");

            ChangeState(ResetState);
        }
    }
}
