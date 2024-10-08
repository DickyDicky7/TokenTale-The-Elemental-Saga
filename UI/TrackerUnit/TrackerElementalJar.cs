using Godot;
using Godot.Collections;
using System.Linq.Expressions;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class TrackerElementalJar : Control
{
	[Export]
	public TextureProgressBar ProgressBar { get; set; }
	public void UpdateProgressColor(Global.Element element)
	{
		this.ProgressBar.TintProgress = AbilityStats.GetInstance().ColorDict[element];
	}
	public void Update(ElementalJar elementalJar)
	{
		this.ProgressBar.Value = elementalJar.CurrentEnergy;
		this.UpdateProgressColor(elementalJar.CurrentElement);
		this.ProgressBar.MaxValue = elementalJar.MaxEnergy;
	}
}
