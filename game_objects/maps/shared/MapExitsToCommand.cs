using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MapExitsToCommand : Resource
{
    //[Export]
    //public NodePath
    //       Exit
    //{
    //    get;
    //    set;
    //}

    [Export]
    public Array<NodePath>
           Exits
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

    [Export]
    public Array<string> AllowableBodyTypes { get; set; } = [ "MainCharacter" ];
    public Node3D Agent                     { get; set; }

    public void    ConnectSignals()
    {
        foreach (NodePath exit in Exits)
        {
            Agent.GetNode<Area3D>(exit ).BodyEntered += Exit_BodyEntered;
        }
    }

    public void DisconnectSignals()
    {
        foreach (NodePath exit in Exits)
        {
            Agent.GetNode<Area3D>(exit ).BodyEntered -= Exit_BodyEntered;
        }
    }

    private void Exit_BodyEntered(Node3D @body)
    {
        foreach (string type in
           AllowableBodyTypes     )
        {
            if (System.Convert.ChangeType(body,
                System.Type   .   GetType($"TokenTaleTheElementalSaga.{type}")) == null)
            {
                return;
            }
        }
        Command       .
        Execute()     ;
    }

    public void Initial(params object[]
                              @objects)
    {
        Command.Initial(      @objects)            ;
        Agent  =              @objects[1] as Node3D;
    }
}





