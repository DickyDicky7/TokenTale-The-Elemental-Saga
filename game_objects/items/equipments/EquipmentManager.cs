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
	private MainCharacter MainCharacter { get; set; }
	public EquipmentManager(MainCharacter mainCharacter)
	{
		this.MainCharacter = mainCharacter;
		Quiver = new Quiver(mainCharacter);
		Boot = new Boot(mainCharacter);
		PowerupsGenerator = new PowerupsGenerator(mainCharacter);

		HealthJarList.Add(new HealthJar(false, mainCharacter));
		HealthJarList.Add(new HealthJar(false, mainCharacter));

		ElementalJarList.Add(new ElementalJar(false, mainCharacter));
		ElementalJarList.Add(new ElementalJar(false, mainCharacter));

		this.AddChildren(mainCharacter);
	}
	private void AddChildren(MainCharacter mainCharacter)
	{
		mainCharacter.AddChild(this.Quiver);
		mainCharacter.AddChild(this.Boot);
		mainCharacter.AddChild(this.PowerupsGenerator);
		mainCharacter.AddChild(this);

		foreach (HealthJar healthJar in HealthJarList)
		{
			mainCharacter.AddChild(healthJar);
		}
		foreach (ElementalJar elementalJar in ElementalJarList)
		{
			mainCharacter.AddChild(elementalJar);
		}
	}
	public void StoreHealth(float storeAmount)
	{
		float excessAmount = storeAmount;
		foreach(HealthJar healthJar in HealthJarList)
		{
			if (healthJar.Available is false)
				continue;
			excessAmount = healthJar.Store(excessAmount);
			if (excessAmount == 0)
				break;
		}
	}
	public float RetriveHealth(float neededAmount)
	{
		float alreadyGetAmount = 0;
		foreach (HealthJar healthJar in HealthJarList)
		{
			if (healthJar.Available is false)
				continue;
			alreadyGetAmount += healthJar.Retrive(neededAmount);
			neededAmount -= alreadyGetAmount;
			if (neededAmount == 0)
				break;
		}
		return alreadyGetAmount;
	}
	public override void _Input(InputEvent @event)
	{
		base._Input(@event);
		if (@event is InputEventKey inputEventKey)
		{
			if (inputEventKey.Pressed)
			{
				if (inputEventKey.Keycode == Key.H)
				{
					if (this.MainCharacter.CurrentHealth < this.MainCharacter.MaxHealth)
					{
						float neededAmount = this.MainCharacter.MaxHealth - this.MainCharacter.CurrentHealth;
						float healAmount = this.RetriveHealth(neededAmount);
						this.MainCharacter.CurrentHealth += healAmount;
						this.MainCharacter.EmitSignal(Character3D.SignalName.HealthChange, -healAmount);
					}
				}
			}
		}
	}
}
