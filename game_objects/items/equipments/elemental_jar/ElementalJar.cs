using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ElementalJar : Equipment
{
	public int Key { get; private set; }
	public Global.Element CurrentElement { get; private set; } = default;
	public int CurrentEnergy { get; private set; } = default;
	public ElementalJar(int Key)
	{
		this.Key = Key;
		this.Available = Available;
		this.Upgradeable = false;
		this.Level = 1;
	}
	public void Store(Global.Element Element, int Energy)
	{
		this.CurrentElement = Element;
		this.CurrentEnergy = Energy;
	}
	public (Global.Element, int) Retrieve()
	{
		return (this.CurrentElement, this.CurrentEnergy);
	}
}
