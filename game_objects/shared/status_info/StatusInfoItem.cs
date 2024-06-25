using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class StatusInfoItem : Resource
{
    [Export]
    public Color FontColor        { get; set; } = Color.Color8(r8: 255, g8: 255, b8: 255, a8: 255);

    [Export]
    public Color FontColorOutline { get; set; } = Color.Color8(r8: 000, g8: 000, b8: 000, a8: 255);

    [Export]
    public int FontSize        { get; set; } = 32;

    [Export]
    public int FontSizeOutline { get; set; } = 08;

    [Export]
    public string Thing { get; set; }
}







