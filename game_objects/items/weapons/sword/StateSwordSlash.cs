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
            Vector2  screenMousePosition =
            Sword.Get_LocalMousePosition()
                 .ConvertToTopDown      ();
//          Vector2  screenMousePosition =
//          Sword.GetScreenMousePosition();
            Sword.AnimatedSprite3D.FlipH =
                     screenMousePosition.X switch
            {
                <= 0 => !false,
                _    =>  false,
            };
            Sword.AnimatedShadow3D.FlipH =
            Sword.AnimatedSprite3D.FlipH ;
            Sword.AnimatedSprite3D.Rotation =
            Sword.AnimatedSprite3D.Rotation
            with { Y = - Mathf.Pi / 2.0f-
                     screenMousePosition.Angle(), };
            Sword.AnimatedShadow3D.Rotation =
            Sword.AnimatedShadow3D.Rotation
            with { Y = - Mathf.Pi / 2.0f-
                     screenMousePosition.Angle(), };
            Sword.Aareaa3D.Rotation = 
            Sword.Aareaa3D.Rotation
            with { Y = -
                     screenMousePosition.Angle(), };
        }
        else
        {
            Sword.AnimatedSprite3D.FlipH =
                          inputDirection.X switch
            {
                <= 0 => !false,
                _    =>  false,
            };
            Sword.AnimatedShadow3D.FlipH =
            Sword.AnimatedSprite3D.FlipH ;
            Sword.AnimatedSprite3D.Rotation = 
            Sword.AnimatedSprite3D.Rotation
            with { Y = - Mathf.Pi / 2.0f-
                          inputDirection.Angle(), };
            Sword.AnimatedShadow3D.Rotation =
            Sword.AnimatedShadow3D.Rotation
            with { Y = - Mathf.Pi / 2.0f-
                          inputDirection.Angle(), };
            Sword.Aareaa3D.Rotation =
            Sword.Aareaa3D.Rotation
            with { Y = -
                          inputDirection.Angle(), };
        }
        Sword.CollisionShape3D.SetDeferred  ("disabled" , false);
        Sword.AnimationPlayerr.AnimationFinished += AnimationPlayer__AnimationFinished;
        Sword.AnimationPlayerr.Play($"SLASH_{Sword.SlashCount}");
        Sword.SlashCount ++  ;
        Sword.SlashCount %= 4;
    }

    
    public override void _Leave()
    {
                    base._Leave();
        Sword.AnimationPlayerr.AnimationFinished -= AnimationPlayer__AnimationFinished;
		Sword.StartCoolDown();
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



