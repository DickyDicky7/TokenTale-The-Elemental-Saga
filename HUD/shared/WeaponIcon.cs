using Godot;
using System;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class WeaponIcon : TextureRect
{
	private Color PickedColor { get; set; } = new Color(255, 255, 0);
	private Color UnpickedColor { get; set; } = new Color(255, 255, 255);
	[Signal]
	public delegate void PickedChangeEventHandler(bool picked);

	public override void _Ready()
	{
		base._Ready();
		this.PickedChange += OnPickedChanged;
	}
	private void OnPickedChanged(bool picked)
	{
		if (picked == true)
		{
			this.SelfModulate = this.PickedColor;
		}
		else
		{
			this.SelfModulate = this.UnpickedColor;
		}
	}
}
