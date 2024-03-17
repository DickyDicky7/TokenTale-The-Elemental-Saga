using Godot;

namespace TokenTaleTheElementalSaga;

public partial class Imp : ElementalMonster
{
    [Export]
    public EyeSight EyeSight { get; set; }

    private float _angle = 0;

    public override void _Process(double @delta)
    {
                    base._Process(       @delta);
    }
}
