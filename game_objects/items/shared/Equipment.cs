using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public abstract partial class Equipment : Item3D
{
	public int Level { get; protected set; }
	public bool Available { get; set; }
	public bool Upgradeable { get; protected set; }
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
