using Godot;

namespace TokenTaleTheElementalSaga.GameObjects.Characters;

[GlobalClass]
public abstract partial class Character : CharacterBody2D
{
    [Export]
    public RayCast2D RayCast2D
    {
        get;
        set;
    }

    public virtual void FollowCharacter(Character @character)
    {

    }

}
