using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MapSpawnAreaToCommand : Resource
{

    [Export]
    public NodePath
           NodePathSpawnArea
    {
        get;
        set;
    }

    [Export]
    public NodePath
           NodePathTimer
    {
        get;
        set;
    }

    [Export]
    public Command
           Command
    {
        get;
        set;
    }


    public          Node3D           Agent     { get; set; }
    public VisibleOnScreenNotifier3D SpawnArea { get; set; }

    public Timer
           Timer
    {
        get;
        set;
    }

    public void    ConnectSignals()
    {
        SpawnArea.ScreenEntered +=
        SpawnArea_ScreenEntered ;

        SpawnArea.ScreenExited  +=
        SpawnArea_ScreenExited  ;
    }


    public void DisconnectSignals()
    {
        SpawnArea.ScreenEntered -=
        SpawnArea_ScreenEntered ;

        SpawnArea.ScreenExited  +=
        SpawnArea_ScreenExited  ;
    }

    public void Initial(params object [ ]
                              @objects)
    {
        Agent =               @objects[1] as Node3D;

        Timer =     Agent.GetNode<   Timer   >(
                             NodePathTimer    )    ;

        SpawnArea = Agent.GetNode<VisibleOnScreenNotifier3D>(
NodePathSpawnArea                                           );

        Command=
        Command.Duplicate(subresources: true)
    as  Command;

        Command.Initial(     @objects[0],
                             @objects[1],
        SpawnArea      )                ;

        Timer.Timeout +=
        Timer_Timeout ;

//         GD.Print(Command.GetInstanceId());
    }

    private void Timer_Timeout()
    {
        Command  .
        Execute();
    }

    private void SpawnArea_ScreenEntered()
    {
        Timer.Start();
    }

    private void SpawnArea_ScreenExited ()
    {
        Timer.@Stop();
    }
}





