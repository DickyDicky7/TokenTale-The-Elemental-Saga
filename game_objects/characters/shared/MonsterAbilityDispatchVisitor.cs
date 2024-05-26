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
	private bool AlreadySet { get; set; } = false;
	public override void Init()
	{
		if (this.AlreadySet == true)
			return;
		foreach (PackedScene packedScene in AvailableMonsterAbilityPackedScene)
		{
			Ability3D ability3D = packedScene.Instantiate<Ability3D>();
			MonsterAbilityDictionary.Add(ability3D.Name, packedScene);
		}
		this.AlreadySet = true;
	}
	public override void VisitMetalMonster(MetalMonster metalMonster)
	{
		metalMonster.AbilityPackedScenes.Add(
			nameof(MiniThunderShock),
			MonsterAbilityDictionary[nameof(MiniThunderShock)]);
	}
	public override void VisitImp(Imp imp)
	{
		imp.AbilityPackedScenes.Add(
			nameof(MiniFireBall),
			MonsterAbilityDictionary[nameof(MiniFireBall)]);
	}
	public override void VisitKoboldPriest(KoboldPriest koboldPriest)
	{
		koboldPriest.AbilityPackedScenes.Add(
			nameof(MiniIceShard),
			MonsterAbilityDictionary[nameof(MiniIceShard)]);
	}
	public override void VisitCyclops(Cyclops cyclops)
	{
		cyclops.AbilityPackedScenes.Add(
			nameof(MiniThrowingRock),
			MonsterAbilityDictionary[nameof(MiniThrowingRock)]);
	}
	public override void VisitRatfolkMage(RatfolkMage ratfolkMage)
	{
		ratfolkMage.AbilityPackedScenes.Add(
			nameof(MiniPenetratingSquirt),
			MonsterAbilityDictionary[nameof(MiniPenetratingSquirt)]);
		ratfolkMage.AbilityPackedScenes.Add(
			nameof(MiniHealSingle),
			MonsterAbilityDictionary[nameof(MiniHealSingle)]);
	}
	public override void VisitBat(Bat bat)
	{
		bat.AbilityPackedScenes.Add(
			nameof(MiniBlowWind),
			MonsterAbilityDictionary[nameof(MiniBlowWind)]);
	}
	public override void VisitHealTotem(HealTotem healTotem)
	{
		healTotem.AbilityPackedScenes.Add(
			nameof(MiniRootTrap),
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