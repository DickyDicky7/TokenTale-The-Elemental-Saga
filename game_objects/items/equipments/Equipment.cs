using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public abstract partial class Equipment : Item3D
{
	[Export]
	public MainCharacter OwnerMainCharacter { get; set; }
	[Export]
	public bool Available { get; set; }
	public bool Upgradeable { get; set; }
	public int Level { get; protected set; }
	public int NextLevelUpgradeCost { get; protected set; }
	[Signal]
	public delegate void JustUpgradeEventHandler();
	[Signal]
	public delegate void TakenEventHandler();
	public override void _Ready()
	{
		base._Ready();
		//Load from saved ?
	}
	public virtual void Upgrade()
	{
		if (Upgradeable == true)
		{
			this.Level++;
		}
	}
}
