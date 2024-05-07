using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class BBVariable : Node
{
    private BBVariable() : base()
    {

    }
    private static BBVariable _instance;
    public  static BBVariable GetInstance()
    {
        if (_instance == null)
            _instance =  new();
        return _instance;
    }
    public StringName ClockwisePriority { get; set; } = "ClockwisePriority";
    public StringName SeeingAngle       { get; set; } = "SeeingAngle"      ;

}
