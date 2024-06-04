using Godot;
using System;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class TrackerHealthJar : Control
{
	[Export]
	public TextureProgressBar ProgressBar { get; set; }
}
