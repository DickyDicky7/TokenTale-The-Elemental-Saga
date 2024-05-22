using Godot;

namespace TokenTaleTheElementalSaga;

public partial class HitsFlashingByModulateGlowVersion : Node
{
    [Export]
    public Color DeadColor { get; set; } = Color.Color8(255, 255, 255, 000);
    [Export]
    public Color HurtColor { get; set; } = Color.Color8(255, 000, 000, 255);
    public Color BaseColor { get; set; }

    [Export]
    public Tween.      EaseType DeadEasingfuncType { get; set; } = Tween.      EaseType.In    ; // For Modulating Smoothly
    [Export]
    public Tween.TransitionType DeadTransitionType { get; set; } = Tween.TransitionType.Linear; // For Modulating Smoothly
    [Export]
    public Tween.      EaseType HurtEasingfuncType { get; set; } = Tween.      EaseType.In    ; // For Modulating Smoothly
    [Export]
    public Tween.TransitionType HurtTransitionType { get; set; } = Tween.TransitionType.Linear; // For Modulating Smoothly

    public AnimatedSprite3D
           AnimatedSprite
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready();

        AnimatedSprite = GetParent<
        AnimatedSprite3D>();
        AnimatedSprite . MaterialOverride  =
        AnimatedSprite . MaterialOverride  .Duplicate( )
                      as Material                       ;
             BaseColor = 
                (Color)                   (
                (  ShaderMaterial  )
        AnimatedSprite . MaterialOverride )
                       .GetShaderParameter( "MODULATE" );
    }

    // TIME IN SECONDS
    public void PlayDeadEffect(
    float @duration,
    float @timeStep,
    bool  @firstActive        )
    {
        Tween tween = CreateTween();
        for (float currentTimeStep  = 0.0f     ;
                   currentTimeStep <= @duration;
                   currentTimeStep += @timeStep)
        {
            if (@firstActive)
            {
                tween.
                TweenProperty (    AnimatedSprite.MaterialOverride , "shader_parameter/MODULATE", DeadColor, @timeStep)
                     .SetEase (DeadEasingfuncType)
                     .SetTrans(DeadTransitionType);
            }
            else
            {
                tween.
                TweenProperty (    AnimatedSprite.MaterialOverride , "shader_parameter/MODULATE", BaseColor, @timeStep)
                     .SetEase (DeadEasingfuncType)
                     .SetTrans(DeadTransitionType);
            }
                @firstActive =
            !   @firstActive ;
        }
                tween.
                TweenProperty (    AnimatedSprite.MaterialOverride , "shader_parameter/MODULATE", BaseColor, @timeStep)
                     .SetEase (DeadEasingfuncType)
                     .SetTrans(DeadTransitionType);
    }

    // TIME IN SECONDS
    public void PlayHurtEffect(
    float @duration,
    float @timeStep,
    bool  @firstActive        )
    {
        Tween tween = CreateTween();
        for (float currentTimeStep  = 0.0f     ;
                   currentTimeStep <= @duration;
                   currentTimeStep += @timeStep)
        {
            if (@firstActive)
            {
                tween.
                TweenProperty (    AnimatedSprite.MaterialOverride, "shader_parameter/MODULATE", HurtColor, @timeStep)
                     .SetEase (HurtEasingfuncType)
                     .SetTrans(HurtTransitionType);
            }
            else
            {
                tween.
                TweenProperty (    AnimatedSprite.MaterialOverride , "shader_parameter/MODULATE", BaseColor, @timeStep)
                     .SetEase (HurtEasingfuncType)
                     .SetTrans(HurtTransitionType);
            }
                @firstActive =
            !   @firstActive ;
        }
                tween.
                TweenProperty (    AnimatedSprite.MaterialOverride , "shader_parameter/MODULATE", BaseColor, @timeStep)
                     .SetEase (HurtEasingfuncType)
                     .SetTrans(HurtTransitionType);
    }

}






