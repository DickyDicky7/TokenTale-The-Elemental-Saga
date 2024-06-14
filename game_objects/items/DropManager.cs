using Godot                     ;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public partial class  DropManager  : Node
{
    public override void _Ready()
    {
                    base._Ready();

        foreach (MapSystem.AvailableMapArea
                           availableMapArea in System.Enum.GetValues
                <MapSystem.AvailableMapArea>())
        {
                SoulOrCoins.Add(availableMapArea, []);
            ElementalTokens.Add(availableMapArea, []);
                  HealDrops.Add(availableMapArea, []);
        }
                             ChildExitingTree +=
                 DropManager_ChildExitingTree   ;
    }

    private void DropManager_ChildExitingTree(Node @node)
    {
        if (@node.IsQueuedForDeletion())
        {
            if (@node is     SoulOrCoin
                             soulOrCoin)
            {
                             SoulOrCoins[CurrentMapArea].Remove(
                             soulOrCoin                        );
            }
            else
            if (@node is ElementalToken
                         elementalToken)
            {
                         ElementalTokens[CurrentMapArea].Remove(
                         elementalToken                        );
            }
			else
			if (@node is HealDrop
						 healDrop)
			{
				HealDrops[CurrentMapArea].Remove(
				healDrop);
			}
		}
    }

    public void Add(
             Item3D
            @item3D)
    {
        if (@item3D is     SoulOrCoin
                           soulOrCoin)
        {
                           SoulOrCoins[CurrentMapArea].Add(
                           soulOrCoin                     );
            AddChild(      soulOrCoin                     );
        }
        else
        if (@item3D is ElementalToken
                       elementalToken)
        {
                       ElementalTokens[CurrentMapArea].Add(
                       elementalToken                     );
            AddChild(  elementalToken                     );
        }
		else
		if (@item3D is HealDrop
					   healDrop)
		{
			HealDrops[CurrentMapArea].Add(
			healDrop);
			AddChild(healDrop);
		}
	}

    public MapSystem.AvailableMapArea
                       CurrentMapArea
    {
        get;
        set;
    }

    private Dictionary<MapSystem.AvailableMapArea, List<    SoulOrCoin>>     SoulOrCoins { get; set; } = [];
    private Dictionary<MapSystem.AvailableMapArea, List<ElementalToken>> ElementalTokens { get; set; } = [];
    private Dictionary<MapSystem.AvailableMapArea, List<HealDrop>> HealDrops { get; set; } = [];

    public void Load()
    {
            SoulOrCoins[CurrentMapArea].ForEach(    soulOrCoin => AddChild(    soulOrCoin));
        ElementalTokens[CurrentMapArea].ForEach(elementalToken => AddChild(elementalToken));
        HealDrops[CurrentMapArea].ForEach(healDrop => AddChild(healDrop));
    }

    public void Save()
    {
        foreach (Node child
             in    GetChildren())
        {
                RemoveChild(
                      child);
        }
    }
}
