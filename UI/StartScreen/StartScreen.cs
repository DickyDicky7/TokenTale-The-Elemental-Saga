using Godot ;
using System;

namespace TokenTaleTheElementalSaga;

public partial class StartScreen : PanelContainer
{
    [Export]
    public Button   StartButton { get; set; }
    [Export]
    public Button SandBoxButton { get; set; }
    [Export]
    public Button  CreditButton { get; set; }
    public override void _Ready()
    {
        base._Ready();
        this. CreditButton.Pressed += SwitchToCredit ;
        this.  StartButton.Pressed += SwitchToGame   ;
        this.SandBoxButton.Pressed += SwitchToSandBox;

        GetNode<SoundManagerBGM_______>(
$"/root/{nameof(SoundManagerBGM_______)}").CrossfadeTo(BGM);
        GetNode<SoundManagerBGMAmbient>(
$"/root/{nameof(SoundManagerBGMAmbient)}").GoSilence  (   );

    }
    private void SwitchToCredit ()
    {
        GetTree().ChangeSceneToPacked(PackedSceneCredit );
    }
    private void SwitchToGame   ()
    {
        GetTree().ChangeSceneToPacked(PackedSceneGame   );
    }
    private void SwitchToSandBox()
    {
        GetTree().ChangeSceneToPacked(PackedSceneSandbox);
    }
    [Export]
    public PackedScene PackedSceneCredit  { get; set; }
    [Export]
    public PackedScene PackedSceneGame    { get; set; }
    [Export]
    public PackedScene PackedSceneSandbox { get; set; }
    [Export]
    public AudioStream BGM { get; set; }
}
