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
		string abilityName = this
			.ElementalBracelet
			.OwnerMainCharacter
			.Cast(this.ElementalBracelet.CurrentElement);
		int energyConsume = AbilityStats.GetInstance().EnergyConsumption[abilityName];
		this.ElementalBracelet.CurrentEnergy -= energyConsume;
		this.ElementalBracelet.EmitSignal(
			ElementalBracelet.SignalName.Cast,
			this.ElementalBracelet.CurrentEnergy);
		ChangeState(ResetState);
	}
	public override void _Leave()
	{
		base._Leave();
		this.ElementalBracelet.StartCoolDown();
	}
}
