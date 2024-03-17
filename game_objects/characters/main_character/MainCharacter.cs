using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MainCharacter : Character2D
{

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);
        //SingletonMainCharacterTracesManager.Instance.Add(Position);
    }
}
