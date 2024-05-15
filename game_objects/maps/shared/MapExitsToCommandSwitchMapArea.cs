using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MapExitsToCommandSwitchMapArea : Resource
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
    public CommandSwitchMapArea
           CommandSwitchMapArea
    {
        get;
        set;
    }

    [Export]
    public Array<string> AllowableBodyTypes { get; set; }
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
        CommandSwitchMapArea.Execute();
    }
}



