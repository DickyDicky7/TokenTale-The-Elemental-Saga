using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateSwordSlash : StateSword
{
    [Export]
    [ExportGroup("Transition ##")]
    public State ResetState { get; set; }

    public override void _Enter()
    {
                    base._Enter();

        Sword.IsInUse = true;
        Vector2 inputDirection =  Extension.GetInputDirection();
        if    ( inputDirection ==
        Vector2.Zero)
        {
            Sword.AnimatedSprite2D.FlipH =
            Sword.GetLocalMousePosition().X switch
            {
                <= 0 => !false,
                _    =>  false,
            };
            Sword.LookAt(Sword.GetGlobalMousePosition());
        }
        else
        {
            Sword.AnimatedSprite2D.FlipH  =
                             inputDirection.X switch
            {
                <= 0 => !false,
                _    =>  false,
            };
            Sword.Rotation = inputDirection.Angle();
        }
        Sword.CollisionShape2D.SetDeferred  ("disabled" , false);
        Sword.AnimationPlayer_.AnimationFinished += AnimationPlayer__AnimationFinished;
        Sword.AnimationPlayer_.Play($"SLASH_{Sword.SlashCount}");
        Sword.SlashCount ++  ;
        Sword.SlashCount %= 4;
    }

    
    public override void _Leave()
    {
                    base._Leave();
        Sword.AnimationPlayer_.AnimationFinished -= AnimationPlayer__AnimationFinished;
    }

    private void AnimationPlayer__AnimationFinished(StringName @animationName)
    {
        switch (@animationName)
        {
            case "SLASH_0":
            case "SLASH_1":
            case "SLASH_2":
            case "SLASH_3":
                ChangeState(ResetState);
                break;
        }
    }
}
