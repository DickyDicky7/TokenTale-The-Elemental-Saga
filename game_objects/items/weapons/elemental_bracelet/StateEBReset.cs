using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class StateEBReset : StateEB
{

	[Export]
	[ExportGroup("Transition ##")]
	public State CastState { get; set; }

	public override void _Enter()
	{
		base._Enter();
		this.ElementalBracelet.IsInUse = false;
	}
	public override void _Leave()
	{
		base._Leave();
	}
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event.IsMousePressed(MouseButton.Right))
		{
			ChangeState(CastState);
		}
	}
}
