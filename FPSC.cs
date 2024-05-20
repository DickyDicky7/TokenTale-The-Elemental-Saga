using Godot;

namespace TokenTaleTheElementalSaga;

public partial class FPSC : RichTextLabel
{
    public override void _Process(double @delta)
    {
                    base._Process(       @delta);

        Text = $"FPS: {Engine.GetFramesPerSecond()}";
    }
}

