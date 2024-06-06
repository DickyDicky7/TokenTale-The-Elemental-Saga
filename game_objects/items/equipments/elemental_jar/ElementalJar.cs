using Godot;
using System;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
public partial class ElementalJar : Equipment
{
	public int Key { get; private set; } = default;
	public Global.Element CurrentElement { get; private set; } = Global.Element.None;
	public int MaxEnergy { get; private set; }
	public int CurrentEnergy { get; private set; } = 0;
	[Signal]
	public delegate void ActionEventHandler(ElementalJar elementalJar);
	[Signal]
	public delegate void TakenEventHandler();
	public ElementalJar(int key, bool available, MainCharacter mainCharacter)
	{
		this.Key = Key;
		this.Available = available;
		this.Upgradeable = false;
		this.Level = -1;
		this.OwnerMainCharacter = mainCharacter;
		this.MaxEnergy = mainCharacter.BoosterManager.MaxEnergy;
	}
	public override void _Ready()
	{
		base._Ready();
		this.OwnerMainCharacter.BoosterManager.EnergyStoneChanged += UpdateMaxEnergy;
	}
	public void BeTaken()
	{
		this.Available = true;
		this.EmitSignal(ElementalJar.SignalName.Action, this);
		this.EmitSignal(ElementalJar.SignalName.Taken);
	}
	private void UpdateMaxEnergy(int newMaxEnergy)
	{
		this.MaxEnergy = newMaxEnergy;
		this.EmitSignal(ElementalJar.SignalName.Action, this);
	}
	public void Store(Global.Element element, int energy)
	{
		this.CurrentElement = element;
		this.CurrentEnergy = energy;
		this.EmitSignal(ElementalJar.SignalName.Action, this);
	}
	public void Dispose(ElementalBracelet elementalBracelet)
	{
		elementalBracelet.CurrentElement = this.CurrentElement;
		elementalBracelet.CurrentEnergy = this.CurrentEnergy;
	}
}
