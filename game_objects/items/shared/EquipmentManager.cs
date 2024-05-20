using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;

public partial class EquipmentManager : Node
{
	private List<Equipment> EquipmentList = new();
	public EquipmentManager()
	{
		EquipmentList.Add(new Quiver());
		EquipmentList.Add(new ElementalBracelet(true, 0));
		EquipmentList.Add(new ElementalBracelet(false, 1));
		EquipmentList.Add(new Boot());
		EquipmentList.Add(new PowerupsGenerator());
		EquipmentList.Add(new ElementalJar(0));
		EquipmentList.Add(new ElementalJar(1));
		EquipmentList.Add(new HealthJar(0));
		EquipmentList.Add(new HealthJar(1));
	}
}
