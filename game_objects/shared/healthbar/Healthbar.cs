using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Healthbar : Sprite3D
{
    [Export]
    public Character3D
           Character3D
    {
        get;
        set;
    }

    public GradientTexture1D
           GradientTexture1D
    {
        get;
        set;
    }

    public override void _Ready()
    {
                    base._Ready();

                Texture   = Texture.Duplicate(  subresources: true  ) as Texture2D;
        GradientTexture1D = Texture
    as  GradientTexture1D ;
        Character3D.HealthChange += Character3D_HealthChange;
    }

    private void Character3D_HealthChange(float damage)
    {
            Scale =
            Scale     with
            {     X = Character3D.CurrentHealth
                    / Character3D.    MaxHealth
            };

        if (Scale.X > 0.8f)
        {
            GradientTexture1D.Gradient.SetColor(0, Color.Color8(000    , 255    , 000, 255));
            GradientTexture1D.Gradient.SetColor(1, Color.Color8(000    , 255    , 000, 255));
        }
        else
        if (Scale.X > 0.6f)
        {
            GradientTexture1D.Gradient.SetColor(0, Color.Color8(255 / 2, 255    , 000, 255));
            GradientTexture1D.Gradient.SetColor(1, Color.Color8(255 / 2, 255    , 000, 255));
        }
        else
        if (Scale.X > 0.4f)
        {
            GradientTexture1D.Gradient.SetColor(0, Color.Color8(255    , 255    , 000, 255));
            GradientTexture1D.Gradient.SetColor(1, Color.Color8(255    , 255    , 000, 255));
        }
        else
        if (Scale.X > 0.2f)
        {
            GradientTexture1D.Gradient.SetColor(0, Color.Color8(255    , 255 / 2, 000, 255));
            GradientTexture1D.Gradient.SetColor(1, Color.Color8(255    , 255 / 2, 000, 255));
        }
        else
        {
            GradientTexture1D.Gradient.SetColor(0, Color.Color8(255    , 000    , 000, 255));
            GradientTexture1D.Gradient.SetColor(1, Color.Color8(255    , 000    , 000, 255));
        }
    }
}
