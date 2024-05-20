using Godot;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class MainCharacter : Character3D
{
    [Export]
    public NavigationAgent3D
           NavigationAgent3D
    {
        get;
        set;
    }

    [Export]
    public MainCharacterAnimatedSprite3DEffect
           MainCharacterAnimatedSprite3DEffect
    {
        get;
        set;
    }

    public   BoosterManager
             BoosterManager
    {
                get;
        private set;
    }

    public EquipmentManager
           EquipmentManager
    {
                get;
        private set;
    }

	public override void _Process(double @delta)
    {
                    base._Process(       @delta);
        //SingletonMainCharacterTracesManager.Instance.Add(Position);
    }

    public override void _UnhandledInput(InputEvent @event)
    {
                    base._UnhandledInput(           @event);

        if (@event.IsActionPressed("DUMMY"))
        {
            GetNode<Node>(nameof(StateMachine)).ProcessMode    =
                                                ProcessModeEnum.Disabled;
        }

        if (@event.IsActionPressed("SPACE")
        &&  GetNode<Node>(nameof(StateMachine)).ProcessMode   ==
                                                ProcessModeEnum.Disabled)
        {
            Vector3 randomPosition =
                    GlobalPosition +
            Vector3.Zero with
            {
                X = (float)GD.RandRange(-5, 5),
                Z = (float)GD.RandRange(-5, 5),
            };
            NavigationAgent3D.TargetPosition =
                              randomPosition ;
        }
    }

    public override void _PhysicsProcess(double @delta)
    {
                    base._PhysicsProcess(       @delta);

        if (GetNode<Node>(nameof(StateMachine)).ProcessMode   ==
                                                ProcessModeEnum.Disabled)
        {
            var destination = NavigationAgent3D.GetNextPathPosition();
            var   direction =
                destination -
             GlobalPosition ;
            Move( direction , @delta);
        }
    }
}















