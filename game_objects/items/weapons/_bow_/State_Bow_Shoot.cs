using Godot;

namespace TokenTaleTheElementalSaga;

public partial class State_Bow_Shoot : State_Bow_
{
    [Export]
    [ExportGroup("Transition ##")]
    public State ResetState { get; set; }

    [Export]
    public PackedScene
           PackedSceneArrow { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        _Bow_.IsInUse = true;
        _Bow_.AnimationPlayerr.Play("SHOOT");
        _Bow_.CollisionShape3D      .SetDeferred("disabled", true);
        _Bow_.AnimationPlayerr      .AnimationFinished += AnimationPlayerr_______AnimationFinished;
//      _Bow_.AnimatedSprite3DMmainn.AnimationFinished += AnimatedSprite3DMmainn_AnimationFinished; ;
//      _Bow_.AnimatedSprite3DEffect.AnimationFinished += AnimatedSprite3DEffect_AnimationFinished;
    
        Arrow arrow =     PackedSceneArrow.Instantiate<
        Arrow>();
              arrow. StartPosition  =
              _Bow_.GlobalPosition  ;
        Vector2 inputDirection = Extension.GetInputDirection();
        if (    inputDirection . IsZero())
              arrow. CeasePosition  =
              _Bow_.
            GetGlobalMousePosition();
        else
              arrow. CeasePosition  =
              _Bow_.GlobalPosition  +
                inputDirection .
              ConvertToTopDown()    * 2.0f;
              arrow.MovingDuration  = 0.5d;
              arrow.MovingDelaying  = 0.3d;
              arrow._Setup
                    (this);
    }

    public override void _Leave()
    {
                    base._Leave();

        _Bow_.AnimationPlayerr      .AnimationFinished -= AnimationPlayerr_______AnimationFinished;
//      _Bow_.AnimatedSprite3DMmainn.AnimationFinished -= AnimatedSprite3DMmainn_AnimationFinished; ;
//      _Bow_.AnimatedSprite3DEffect.AnimationFinished -= AnimatedSprite3DEffect_AnimationFinished;
    }

    private void AnimatedSprite3DMmainn_AnimationFinished()
    {
        if (_Bow_
                .AnimatedSprite3DMmainn.Animation == "SHOOT")
        {
            _Bow_
                .AnimatedSprite3DEffect
                .Play("SHOOT");
        }
    }

    private void AnimatedSprite3DEffect_AnimationFinished()
    {
        if (_Bow_
                .AnimatedSprite3DEffect.Animation == "SHOOT")
        {
            _Bow_
                .AnimatedSprite3DEffect
                .Play("RESET");

            ChangeState(ResetState);
        }
    }

    private void AnimationPlayerr_______AnimationFinished(StringName @animationName)
    {
            ChangeState(ResetState);
    }
}






