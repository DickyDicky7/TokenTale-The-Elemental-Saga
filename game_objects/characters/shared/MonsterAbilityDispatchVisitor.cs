using Godot;
using Godot.Collections;
using System;
namespace TokenTaleTheElementalSaga;
//Visitor pattern: Concrete Visitor
public partial class MonsterAbilityDispatchVisitor : MonsterVisitor
{
	[Export]
	public Array<PackedScene> AvailableMonsterAbilityPackedScene { get; set; }
	public System.Collections.Generic.Dictionary<Type, Ability3D>
		MonsterAbilityDictionary{ get; private set; } = new();
	public override void _Ready()
	{
		base._Ready();
		foreach (PackedScene packedScene in AvailableMonsterAbilityPackedScene)
		{
			Ability3D ability3D = packedScene.Instantiate<Ability3D>();
			MonsterAbilityDictionary.Add(ability3D.GetType(), ability3D);
		}
	}
	public override void VisitMetalMonster(MetalMonster metalMonster)
	{
		metalMonster.Abilities.Add(
			typeof(MiniThunderShock),
			MonsterAbilityDictionary[typeof(MiniThunderShock)]);
	}
	public override void VisitImp(Imp imp)
	{
		imp.Abilities.Add(
			typeof(MiniFireBall),
			MonsterAbilityDictionary[typeof(MiniFireBall)]);
	}
	public override void VisitKoboldPriest(KoboldPriest koboldPriest)
	{
		koboldPriest.Abilities.Add(
			typeof(MiniIceShard),
			MonsterAbilityDictionary[typeof(MiniIceShard)]);
	}
	public override void VisitCyclops(Cyclops cyclops)
	{
		cyclops.Abilities.Add(
			typeof(MiniThrowingRock),
			MonsterAbilityDictionary[typeof(MiniThrowingRock)]);
	}
	public override void VisitRatfolkMage(RatfolkMage ratfolkMage)
	{
		ratfolkMage.Abilities.Add(
			typeof(MiniPenetratingSquirt),
			MonsterAbilityDictionary[typeof(MiniPenetratingSquirt)]);
		ratfolkMage.Abilities.Add(
			typeof(MiniHealSingle),
			MonsterAbilityDictionary[typeof(MiniHealSingle)]);
	}
	public override void VisitBat(Bat bat)
	{
		bat.Abilities.Add(
			typeof(MiniBlowWind),
			MonsterAbilityDictionary[typeof(MiniBlowWind)]);
	}
	public override void VisitHealTotem(HealTotem healTotem)
	{
		healTotem.Abilities.Add(
			typeof(MiniRootTrap),
			MonsterAbilityDictionary[typeof(MiniRootTrap)]);
	}
	public override void VisitGhost(Ghost ghost)
	{
		
	}
	public override void VisitMinotaur(Minotaur minotaur)
	{
		
	}
	public override void VisitCat(Cat cat)
	{

	}
	public override void VisitSkeleton(Skeleton skeleton)
	{

	}
}

// Cách giải quyết vấn đề Dictionary
// Lưu ý: Duplicate() giống new(): chỉ tại cái node đó thôi, ko tạo node con
// Cách giải quyết: Tạo 1 class như sau
//[GlobalClass]
//[Tool]
//public partial class  A : Resource
//{
//	[Export]
//	public string TypeName { get; set; }
//	[Export]
//	public PackedScene Ability { get; set; }
//}

//lúc đó class DispatchVistor chỉ cần export Array<A>