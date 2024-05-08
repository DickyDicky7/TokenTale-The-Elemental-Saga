using Godot;

namespace TokenTaleTheElementalSaga;

public partial class HitsFlashing : Node
{
    [Export]
    public ShaderMaterial ShaderMaterialToDuplicate { get; set; }
    public ShaderMaterial ShaderMaterial            { get; set; }

    [Export]
    public Color DeadColor { get; set; } = Color.Color8(255, 000, 000, 255);
    [Export]
    public Color HurtColor { get; set; } = Color.Color8(255, 255, 255, 255);

    [Export]
    public CompressedTexture2D
                   SpriteSheet
    {
        get;
        set;
    }

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
        AnimatedSprite3D          >();
        ShaderMaterial =
        ShaderMaterialToDuplicate
                       .Duplicate(subresources: true) as
        ShaderMaterial;
        AnimatedSprite.MaterialOverride =
        ShaderMaterial;
        ShaderMaterial.SetShaderParameter("tex"        , SpriteSheet);
        ShaderMaterial.SetShaderParameter("y_billboard", false      );
        //ProcessMode =
        //ProcessModeEnum
        //.Disabled;
    }

    // TIME IN SECONDS
    public void PlayDeadEffect(
    float @duration,
    float @timeStep,
    bool  @firstActive        )
    {
        ShaderMaterial.SetShaderParameter("f_lashcolor", DeadColor);
        Tween tween = CreateTween();
        for (float currentTimeStep  = 0.0f     ;
                   currentTimeStep <= @duration;
                   currentTimeStep += @timeStep)
        {
              tween   .
              TweenCallback(Callable.From(() =>
              {
        ShaderMaterial.SetShaderParameter("active",
                                      firstActive);
                                      firstActive =
                                    ! firstActive ;
              }))     .SetDelay(@timeStep);
        }
    }

    // TIME IN SECONDS
    public void PlayHurtEffect(
    float @duration,
    float @timeStep,
    bool  @firstActive        )
    {
        ShaderMaterial.SetShaderParameter("f_lashcolor", HurtColor);
        Tween tween = CreateTween();
        for (float currentTimeStep  = 0.0f     ;
                   currentTimeStep <= @duration;
                   currentTimeStep += @timeStep)
        {
              tween   .
              TweenCallback(Callable.From(() =>
              {
        ShaderMaterial.SetShaderParameter("active",
                                      firstActive);
                                      firstActive =
                                    ! firstActive ;
              }))     .SetDelay(@timeStep);
        }
    }
}
