using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class StateEBCast : StateEB
{
	[Export]
	[ExportGroup("Transition ##")]
	public State ResetState { get; set; }

	public override void _Enter()
	{
		base._Enter();
		this.ElementalBracelet.IsInUse = true;
		this.ElementalBracelet.OwnerMainCharacter.Cast(this.ElementalBracelet.CurrentElement);
		ChangeState(ResetState);
	}
	public override void _Leave()
	{
		base._Leave();
	}
}
