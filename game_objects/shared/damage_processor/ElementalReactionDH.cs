using Godot;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
public partial class ElementalReactionDH : BaseDH
{
	public Global.Element PassiveElement { get; private set; }
	public Global.Element ActiveElement { get; private set; }
	public bool IsElementMonster { get; private set; }
	public ElementalReactionDH(
		Global.Element PassiveElement,
		Global.Element ActiveElement,
		bool IsElementMosnter)
	{
		this.PassiveElement = PassiveElement;
		this.ActiveElement = ActiveElement;
		this.IsElementMonster = IsElementMosnter;
	}
	public override void ProcessDamage(float Damage)
	{
		Global.ReactionType ReactionType = DecideReaction(this.PassiveElement, this.ActiveElement);
		RandomNumberGenerator rand = new();
		if (IsElementMonster)
		{
			switch (ReactionType)
			{
				case Global.ReactionType.Risk:
					Damage = 0;
					break;
				case Global.ReactionType.Warning:
					Damage = (rand.RandfRange(0.3f, 0.7f)) * Damage;
					break;
				case Global.ReactionType.Buff:
					Damage = (rand.RandfRange(1.3f, 1.5f)) * Damage;
					break;
				default:
					//nothing happened
					break;
			}
		}
		else
		{
			switch (ReactionType)
			{
				case Global.ReactionType.Warning:
					Damage = (rand.RandfRange(1.1f, 1.3f)) * Damage;
					break;
				case Global.ReactionType.Buff:
					Damage = (rand.RandfRange(1.4f, 1.6f)) * Damage;
					break;
				default:
					//nothing happened
					break;
			}
		}
		NextHandler.ProcessDamage(Damage);
	}
	public static Global.ReactionType DecideReaction(
		Global.Element Passive, 
		Global.Element Active)
	{
		return Global.ReactionTable[(int)Passive][(int)Active];
	}
}
