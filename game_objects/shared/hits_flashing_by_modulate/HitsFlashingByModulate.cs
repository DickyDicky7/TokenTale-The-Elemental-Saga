using Godot;

namespace TokenTaleTheElementalSaga;

public partial class HitsFlashingByModulate : Node
{
    [Export]
    public Color DeadColor { get; set; } = Color.Color8(255, 000, 000, 255);
    [Export]
    public Color HurtColor { get; set; } = Color.Color8(255, 255, 255, 000);
    public Color BaseColor { get; set; }

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
             BaseColor =
        AnimatedSprite . Modulate;
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
              tween                 .
              TweenCallback(Callable.From(() =>
              {
                  if (@firstActive)
                  {
                      AnimatedSprite.Modulate = DeadColor;
                  }
                  else
                  {
                      AnimatedSprite.Modulate = BaseColor;
                  }
                      @firstActive =
                    ! @firstActive ;
              }))                   .SetDelay (@timeStep);
        }
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
              tween                 .
              TweenCallback(Callable.From(() =>
              {
                  if (@firstActive)
                  {
                      AnimatedSprite.Modulate = HurtColor;
                  }
                  else
                  {
                      AnimatedSprite.Modulate = BaseColor;
                  }
                      @firstActive =
                    ! @firstActive ;
              }))                   .SetDelay (@timeStep);
        }
    }

}



