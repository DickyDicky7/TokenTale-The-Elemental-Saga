using Godot                                              ;

           namespace TokenTaleTheElementalSaga           ;

public partial class MainCharacterAnimatedSprite3DEffect : Node3D
{
    public enum Effect
    {
                EFFECT_ELECTRIC,
                EFFECT_EMPTY   ,
                EFFECT_FIRE    ,
                EFFECT_ICE     ,
                EFFECT_ROCK    ,
                EFFECT_WATER   ,
                EFFECT_WIND    ,
                EFFECT_WOOD    ,
    }

    [Export]
    public AnimationPlayer
           AnimationPlayer
    {
        get;
        set;
    }

    [Export]
    public Effect
    CurrentEffect
    {
        get => System.Enum.Parse<Effect>(AnimationPlayer.CurrentAnimation);
        set =>                           AnimationPlayer.Play
(value.ToString());
    }
}














