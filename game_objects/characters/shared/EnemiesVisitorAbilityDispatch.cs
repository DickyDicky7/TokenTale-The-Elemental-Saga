using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

//Visitor pattern: Concrete Visitor
[Tool       ]
[GlobalClass]
public partial class EnemiesVisitorAbilityDispatch
                   : EnemiesVisitor
{
    [Export]
    public     Array      <PackedScene>
    AvailableEnemiesAbilityPackedScene
    {
        get;
        set;
    } = [ ];

    public System.Collections.Generic.Dictionary<string, PackedScene>
                        EnemiesAbilityDictionary
    {
                get;
        private set;
    } = [ ];

    private bool
          AlreadySet
    {
        get;
        set;
    } = false;
    
    public override void Init()
    {
        if (this.AlreadySet == true)
            return;

        foreach (PackedScene
                 packedScene  in  AvailableEnemiesAbilityPackedScene)
        {
            Ability3D
            ability3D =  packedScene.Instantiate<
            Ability3D>();
            EnemiesAbilityDictionary.Add(ability3D.Name, packedScene);
        
        }

            this.AlreadySet =  true;
    }

    public override void Visit(MetalMonster metalMonster)
    {
        metalMonster.AbilityPackedScenes.Add(
                                       nameof(MiniThunderShock)
        ,     EnemiesAbilityDictionary[nameof(MiniThunderShock)]);
    }

    public override void Visit(Imp imp)
    {
       imp    .    AbilityPackedScenes.Add(
                                     nameof(MiniFireBall)
        ,   EnemiesAbilityDictionary[nameof(MiniFireBall)]);
    }

    public override void Visit(KoboldPriest koboldPriest)
    {
        koboldPriest.AbilityPackedScenes.Add(
                                       nameof(MiniIceShard)
        ,     EnemiesAbilityDictionary[nameof(MiniIceShard)]);
    }

    public override void Visit(Cyclops cyclops)
    {
        cyclops.AbilityPackedScenes.Add(
                                  nameof(MiniThrowingRock)
        ,EnemiesAbilityDictionary[nameof(MiniThrowingRock)]);
    }

    public override void Visit(RatfolkMage ratfolkMage)
    {
        ratfolkMage.AbilityPackedScenes.Add(
                                      nameof(MiniPenetratingSquirt)
        ,    EnemiesAbilityDictionary[nameof(MiniPenetratingSquirt)]);
        ratfolkMage.AbilityPackedScenes.Add(
                                      nameof(MiniHealSingle       )
        ,    EnemiesAbilityDictionary[nameof(MiniHealSingle       )]);
    }

    public override void Visit(Bat bat)
    {
      bat    .    AbilityPackedScenes.Add(
                                    nameof(MiniBlowWind)
       ,   EnemiesAbilityDictionary[nameof(MiniBlowWind)]);
    }

    public override void Visit(HealTotem healTotem)
    {
        healTotem.AbilityPackedScenes.Add(
                                    nameof(MiniRootTrap)
        ,  EnemiesAbilityDictionary[nameof(MiniRootTrap)]);
    }

    public override void Visit(Ghost ghost)
    {

    }

    public override void Visit(Minotaur minotaur)
    {

    }

    public override void Visit(Cat cat)
    {

    }

    public override void Visit(Skeleton skeleton)
    {

    }
}
