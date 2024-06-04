using Godot;
using Godot.Collections;
using System;
namespace TokenTaleTheElementalSaga;
public partial class ElementalIcon : WeaponIcon
{
	[Export]
	public TextureRect Token { get; set; }
	public void Update(Global.Element element)
	{
		if (element == Global.Element.None)
		{
			this.Token.Visible = false;
		}
		else
		{
			this.Token.Visible = true; 
			this.Token.SelfModulate = AbilityStats.GetInstance().ColorDict[element];
		}
	}
}
