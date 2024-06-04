using Godot            ;
using Godot.Collections;

namespace TokenTaleTheElementalSaga                      ;

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

    public Dictionary<Global.Element, Effect> EffectDictionary { get; private set; } = [];
	
    public override void _Ready()
	{
		            base._Ready();
        
        EffectDictionary.Add(Global.Element.Fire    , Effect.EFFECT_FIRE    );
		EffectDictionary.Add(Global.Element.Water   , Effect.EFFECT_WATER   );
		EffectDictionary.Add(Global.Element.Wind    , Effect.EFFECT_WIND    );
		EffectDictionary.Add(Global.Element.Ice     , Effect.EFFECT_ICE     );
		EffectDictionary.Add(Global.Element.Electric, Effect.EFFECT_ELECTRIC);
		EffectDictionary.Add(Global.Element.Earth   , Effect.EFFECT_ROCK    );
		EffectDictionary.Add(Global.Element.Wood    , Effect.EFFECT_WOOD    );
		EffectDictionary.Add(Global.Element.None    , Effect.EFFECT_EMPTY   );
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

















