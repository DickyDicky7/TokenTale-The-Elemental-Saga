using Godot;

namespace TokenTaleTheElementalSaga;

[Tool       ]
[GlobalClass]
public partial class ChessAndItemResource : Resource
{
    [Export]
    public CompressedTexture2D
                 ItemTexture
    {
        get;
        set;
    }

    [Export]
    public string 
    ItemClassName
    {
        get;
        set;
    }

    [Export]
    public string
    Item_____Name
    {
        get;
        set;
    }

    public  Item3D
         GetItem3D()
    {
    return (Item3D)System.Activator.CreateInstance(System.Type.GetType($"TokenTaleTheElementalSaga.{ItemClassName}"));
    }
}



















