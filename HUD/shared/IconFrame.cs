using Godot;
using System;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class IconFrame : TextureRect
{
	private Color ChosenColor { get; set; } = new Color(255, 255, 0);
	private Color NormalColor { get; set; } = new Color(255, 255, 255);
	[Signal]
	public delegate void ChosenChangedEventHandler(bool picked);

	public override void _Ready()
	{
		base._Ready();
		this.ChosenChanged += OnChosenChanged;
	}
	private void OnChosenChanged(bool picked)
	{
		if (picked == true)
		{
			this.SelfModulate = this.ChosenColor;
		}
		else
		{
			this.SelfModulate = this.NormalColor;
		}
	}
}
