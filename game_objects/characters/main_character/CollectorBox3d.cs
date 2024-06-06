using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class CollectorBox3d : CustomArea3D
{
	protected override void OnAreaEntered(Area3D @area3D)
	{
		if (this.GetParent() is MainCharacter tempMainCharacter)
		{
			if (area3D.GetParent() is ElementalToken tempElementalToken)
				TakeElementalToken(tempMainCharacter, tempElementalToken);
			else if (area3D.GetParent() is SoulOrCoin tempCoin)
				TakeCoin(tempMainCharacter, tempCoin);
			else if (area3D.GetParent() is HealDrop tempHealDrop)
				TakeHeal(tempMainCharacter, tempHealDrop);
		}
	}
	protected override void OnBodyEntered(Node3D @node3D)
	{
		if (this.GetParent() is MainCharacter tempMainCharacter)
		{
			if (node3D is ElementalToken tempElementalToken)
				TakeElementalToken(tempMainCharacter, tempElementalToken);
			else if (node3D is SoulOrCoin tempCoin)
				TakeCoin(tempMainCharacter, tempCoin);
			else if (node3D is HealDrop tempHealDrop)
				TakeHeal(tempMainCharacter, tempHealDrop);
		}
	}
	private void TakeElementalToken(MainCharacter mainCharacter, ElementalToken elementalToken)
	{
		foreach (ElementalBracelet elementalBracelet in mainCharacter.WeaponsController.Bracelets)
		{
			if (elementalBracelet.CurrentElement == Global.Element.None)
			{
				elementalBracelet.CurrentElement = elementalToken.Element;
				elementalBracelet.CurrentEnergy = mainCharacter.BoosterManager.MaxEnergy;
				elementalBracelet.EmitSignal(ElementalBracelet.SignalName.Recharge, elementalBracelet);
				elementalToken.QueueFree();
				break;
			}
		}
	}
	private void TakeCoin(MainCharacter mainCharacter, SoulOrCoin coin)
	{
		mainCharacter.CurrentCoin += coin.RandomizeAmountOfCoin();
		mainCharacter.EmitSignal(MainCharacter.SignalName.CoinChanged, mainCharacter.CurrentCoin);
		coin.QueueFree();
	}
	private void TakeHeal(MainCharacter mainCharacter, HealDrop healDrop)
	{
		float health = healDrop.RandomizeAmouthOfHealth();
		float oldHealth = mainCharacter.CurrentHealth;
		float newHealth = oldHealth + health;
		float excessAmount = 0;
		if (newHealth > mainCharacter.MaxHealth)
		{
			excessAmount = (newHealth - mainCharacter.MaxHealth) * 0.7f;
			newHealth = mainCharacter.MaxHealth;
		}
		float damage = oldHealth - newHealth;
		mainCharacter.CurrentHealth = newHealth;
		mainCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
		healDrop.QueueFree();
		if (excessAmount > 0)
		{
			mainCharacter.EquipmentManager.StoreHealth(excessAmount);
		}
	}
	public override void _Ready()
	{
		base._Ready();
		this.StartWatching();
	}
}
