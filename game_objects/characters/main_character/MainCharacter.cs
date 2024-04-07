using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MainCharacter : Character3D
{

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);
        //SingletonMainCharacterTracesManager.Instance.Add(Position);
    }
}
