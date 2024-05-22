using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool       ]
[GlobalClass]
public partial class StatusInfoItemElemental : StatusInfoItem
{

    public static Array<Color>     ElementalColors =
    [
        Color.Color8(255,000,000,255),
        Color.Color8(000,128,255,255),
        Color.Color8(128,255,128,255),
        Color.Color8(000,255,255,255),
        Color.Color8(255,000,255,255),
        Color.Color8(255,255,000,255),
        Color.Color8(000,255,000,255),
        Color.Color8(255,255,255,255),
    ];

    private Global.Element
                   element     =
            Global.Element.None;

    [Export]
    public  Global.Element
                   Element
    {
        get =>     element;
        set
        {
                   element = value;
                 FontColor = ElementalColors[(int)Element];
        }
    }

    public StatusInfoItemElemental()
    {
                 FontColor = ElementalColors[(int)Element];
    }
}






