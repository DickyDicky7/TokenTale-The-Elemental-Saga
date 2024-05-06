using Godot;
using System;
using System.Runtime.CompilerServices;
using TokenTaleTheElementalSaga;

[GlobalClass]
public partial class HurtBox3d : Area3D
{
	public Character3D Character3D { get; set; }
	public bool Hurt { get; set; } = false;

	protected void OnAreaEntered(Area3D area3D)
	{
		Character3D.Health--;
		Hurt = true;
	}
	public void StartWatching()
	{
		this.AreaEntered += OnAreaEntered;
	}
	public void StopWatching()
	{
		this.AreaEntered -= OnAreaEntered;
	}
}
