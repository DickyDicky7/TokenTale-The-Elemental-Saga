using @Godot;
using System;

namespace TokenTaleTheElementalSaga;

public partial class  ControlBoard : PanelContainer
{
    [Export]
    public Button @ResumeButton { get; set; }
    [Export]
    public Button RestartButton { get; set; }
    [Export]
    public Button    ExitButton { get; set; }

    public override void _Ready()
    {
                    base._Ready();
        this.@ResumeButton.Pressed += @Resume;
        this.RestartButton.Pressed += Restart;
        this.   ExitButton.Pressed +=    Exit;
    }

    private void @Resume()
    {
        this.Visible = false;
        this.EmitSignal(ControlBoard.SignalName.VisibilityChanged);
    }

    private void Restart()
    {
        GetTree().Paused = false;
        GetTree().ReloadCurrentScene();
    }

    private void    Exit()
    {
        GetTree().Paused = false;
        GetTree().ChangeSceneToPacked(GD.Load<PackedScene>("res://UI/StartScreen/StartScreen.tscn"));
    }
}
