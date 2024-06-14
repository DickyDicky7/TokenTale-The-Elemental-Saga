using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class CreditScroll : ScrollContainer
{
	private int PreviousScrollV { get; set; } = 0;
	public override void _Ready()
	{
		base._Ready();
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
		this.ScrollVertical += 1;
		if (this.ScrollVertical == this.PreviousScrollV)
		{
			
		}
		this.PreviousScrollV = this.ScrollVertical;
	}
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton inputEventMouseButton)
		{
			if (inputEventMouseButton.ButtonIndex == MouseButton.WheelUp ||
				inputEventMouseButton.ButtonIndex == MouseButton.WheelDown)
			{
				AcceptEvent();
			}
			if (inputEventMouseButton.ButtonIndex == MouseButton.Left)
			{
				//this.ScrollVertical = 0;
			}
		}
	}
}
