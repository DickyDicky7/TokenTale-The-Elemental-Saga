using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[Tool       ]
[GlobalClass]
public partial class AlliesVisitorAbilityDispatch : AlliesVisitor
{
    [Export]
    public   Array<       PackedScene>
    AvailableAlliesAbilityPackedScene { get; set; } = [];
    
    public  System.Collections.Generic.Dictionary<string, PackedScene>
            AlliesAbilityDictionary
    { get; private set; } = [];

    public override void Init()
    {
        foreach (PackedScene
                 packedScene in
    AvailableAlliesAbilityPackedScene)
        {
            Ability3D ability =                        packedScene.Instantiate<
            Ability3D>();
            AlliesAbilityDictionary.Add(ability.Name , packedScene            );
        }
    }

    public override void VisitMainCharacter(MainCharacter mainCharacter)
    {
        mainCharacter.AbilityPackedScenes.Add(
            nameof(FireBall), AlliesAbilityDictionary[nameof(FireBall)]);
        mainCharacter.AbilityPackedScenes.Add(
            nameof(PenetratingSquirt), AlliesAbilityDictionary[nameof(PenetratingSquirt)]);
        mainCharacter.AbilityPackedScenes.Add(
            nameof(AirSurge), AlliesAbilityDictionary[nameof(AirSurge)]);
        mainCharacter.AbilityPackedScenes.Add(
            nameof(Frostburn), AlliesAbilityDictionary[nameof(Frostburn)]);
        mainCharacter.AbilityPackedScenes.Add(
            nameof(Lightning), AlliesAbilityDictionary[nameof(Lightning)]);
        mainCharacter.AbilityPackedScenes.Add(
            nameof(SkyStrike), AlliesAbilityDictionary[nameof(SkyStrike)]);
        mainCharacter.AbilityPackedScenes.Add(
            nameof(RootTrap), AlliesAbilityDictionary[nameof(RootTrap)]);
    }
}
