using Godot;
using System;
namespace TokenTaleTheElementalSaga;
//Visitor pattern: abstract visitor
[GlobalClass]
[Tool]
public abstract partial class MonsterVisitor : Resource
{
	public abstract void VisitMetalMonster(MetalMonster metalMonster);
	public abstract void VisitImp(Imp imp);
	public abstract void VisitKoboldPriest(KoboldPriest koboldPriest);
	public abstract void VisitCyclops(Cyclops cyclops);
	public abstract void VisitRatfolkMage(RatfolkMage ratfolkMage);
	public abstract void VisitBat(Bat bat);
	public abstract void VisitHealTotem(HealTotem healTotem);
	public abstract void VisitGhost(Ghost ghost);
	public abstract void VisitMinotaur(Minotaur minotaur);
	public abstract void VisitCat(Cat cat);
	public abstract void VisitSkeleton(Skeleton skeleton);
}