using Godot;
using GodotStateCharts;

namespace TokenTaleTheElementalSaga.GameObjects.Items.Shared;

public abstract partial class BaseItem : Area2D
{
    [Export] public CollisionShape2D CollisionShape2DHitbox { get; set; }
    [Export] public AnimationTree   AnimationTree   { get; set; }
    [Export] public AnimationPlayer AnimationPlayer { get; set; }
    [Export]
    public Node NodeStateChart
    {
        get => null;
        set => _stateChart = StateChart.Of(value);
    }

    protected StateChart
             _stateChart;

    public abstract void Wield();
}
