using Godot;

namespace TokenTaleTheElementalSaga;

public partial class ChessAndItem : Node3D
{
    [Export]
    public ChessAndItemResource
           ChessAndItemResource
    {
        get;
        set;
    }

    [Export]
    public Area3D
           Hitbox
    {
        get;
        set;
    }

    [Export]
    public Sprite3D
           Sprite3D
    {
        get;
        set;
    }

    [Export]
    public AnimationPlayer
           AnimationPlayer
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready();

        if (ChessAndItemResource!=null)
        {
                        Sprite3D.    Texture= 
            ChessAndItemResource.ItemTexture;
        }
        Hitbox.BodyEntered +=
        Hitbox_BodyEntered;
        AnimationPlayer.AnimationFinished +=
        AnimationPlayer_AnimationFinished;
    }

    private void AnimationPlayer_AnimationFinished(StringName @animationName)
    {
        if (@animationName == "@OPEN")
        {
            AnimationPlayer.Play("CLOSE");
        }
        if (@animationName == "CLOSE")
        {
            Sprite3D    .Texture = null;
            ChessAndItemResource = null;
        }
    }

    private void Hitbox_BodyEntered(Node3D @body)
    {
        if (@body
        is  MainCharacter
            mainCharacter
           )
        {
            AnimationPlayer.Play("@OPEN");
            //Code to feed item to main character
            //Note: if(ChestAndItemResource != null)
            //         ChestAndItemResource.GetItem3D()
            //         => this method returns new instance of Item3D based on ChestAndItemResource.ItemClassName
        }
    }
}








