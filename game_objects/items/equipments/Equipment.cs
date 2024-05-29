using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public abstract partial class Equipment : Item3D
{
	[Export]
	public bool Available { get; set; }
	public bool Upgradeable { get; set; }
	public int Level { get; protected set; }
	public int NextLevelUpgradeCost { get; protected set; }
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
