using Godot;
using Godot.Collections;
using System;
namespace TokenTaleTheElementalSaga;
//Visitor pattern: Concrete Visitor
[Tool]
[GlobalClass]
public partial class MonsterAbilityDispatchVisitor : MonsterVisitor
{
	[Export]
	public Array<PackedScene> AvailableMonsterAbilityPackedScene { get; set; } = [];
	public System.Collections.Generic.Dictionary<string, PackedScene>
		MonsterAbilityDictionary{ get; private set; } = new();
	public MonsterAbilityDispatchVisitor():base()
	{
		foreach (PackedScene packedScene in AvailableMonsterAbilityPackedScene)
		{
			Ability3D ability3D = packedScene.Instantiate<Ability3D>();
			GD.Print(ability3D.Name);
			MonsterAbilityDictionary.Add(ability3D.Name, packedScene);
		}
	}
	public override void VisitMetalMonster(MetalMonster metalMonster)
	{
		metalMonster.AbilityPackedScenes.Add(
			typeof(MiniThunderShock),
			MonsterAbilityDictionary[nameof(MiniThunderShock)]);
	}
	public override void VisitImp(Imp imp)
	{
		imp.AbilityPackedScenes.Add(
			typeof(MiniFireBall),
			MonsterAbilityDictionary[nameof(MiniFireBall)]);
	}
	public override void VisitKoboldPriest(KoboldPriest koboldPriest)
	{
		koboldPriest.AbilityPackedScenes.Add(
			typeof(MiniIceShard),
			MonsterAbilityDictionary[nameof(MiniIceShard)]);
	}
	public override void VisitCyclops(Cyclops cyclops)
	{
		cyclops.AbilityPackedScenes.Add(
			typeof(MiniThrowingRock),
			MonsterAbilityDictionary[nameof(MiniThrowingRock)]);
	}
	public override void VisitRatfolkMage(RatfolkMage ratfolkMage)
	{
		ratfolkMage.AbilityPackedScenes.Add(
			typeof(MiniPenetratingSquirt),
			MonsterAbilityDictionary[nameof(MiniPenetratingSquirt)]);
		ratfolkMage.AbilityPackedScenes.Add(
			typeof(MiniHealSingle),
			MonsterAbilityDictionary[nameof(MiniHealSingle)]);
	}
	public override void VisitBat(Bat bat)
	{
		bat.AbilityPackedScenes.Add(
			typeof(MiniBlowWind),
			MonsterAbilityDictionary[nameof(MiniBlowWind)]);
	}
	public override void VisitHealTotem(HealTotem healTotem)
	{
		healTotem.AbilityPackedScenes.Add(
			typeof(MiniRootTrap),
			MonsterAbilityDictionary[nameof(MiniRootTrap)]);
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