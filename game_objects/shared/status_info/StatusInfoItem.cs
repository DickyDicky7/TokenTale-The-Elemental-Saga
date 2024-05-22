using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StatusInfoItem : Resource
{
    [Export]
    public Color
           Color
    {
        get;
        set;
    } =    Color
      .    Color8(r8: 255,
                  g8: 255,
                  b8: 255,
                  a8: 255);

    [Export]
    public string 
           Thing
    {
        get;
        set;
    }
}







