using Godot;
using System;
using System.Collections.Generic;
namespace TokenTaleTheElementalSaga;

public partial class EquipmentManager : Node
{
	public Quiver Quiver { get; private set; }
	public Boot Boot { get; private set; }
	public PowerupsGenerator PowerupsGenerator { get; private set; }
	public List<HealthJar> HealthJarList { get; private set; } = new();
	public List<ElementalJar> ElementalJarList { get; private set; } = new();
	public EquipmentManager()
	{
		Quiver = new Quiver();
		Boot = new Boot();
		PowerupsGenerator = new PowerupsGenerator();

		HealthJarList.Add(new HealthJar(0));
		HealthJarList.Add(new HealthJar(1));

		ElementalJarList.Add(new ElementalJar(0));
		ElementalJarList.Add(new ElementalJar(1));
	}
}
