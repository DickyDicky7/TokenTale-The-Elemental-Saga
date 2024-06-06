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
    [Export]
    public int Key { get; set; } = -1;

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
            if (ChessAndItemResource != null)
            {
                Item3D item3D = this.ChessAndItemResource.GetItem3D();
                if (item3D is Booster booster && this.Key != -1)
                {
                    booster.Key = this.Key;
                    mainCharacter.BoosterManager.TakeBooster(booster);
                }
                else if (item3D is Weapon weapon)
                {

                }
                else if (item3D is Equipment equipment)
                {

                }
            }
        }
    }
}








