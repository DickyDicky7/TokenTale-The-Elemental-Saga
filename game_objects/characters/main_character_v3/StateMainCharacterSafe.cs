using Godot;

namespace TokenTaleTheElementalSaga;

public partial class StateMainCharacterSafe : StateMainCharacter
{
    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        MainCharacter
            .EyeSight
            .FollowPosition(MainCharacter.GetLocalMousePosition());
    }
}
