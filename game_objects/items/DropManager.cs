using Godot                     ;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public partial class
                   DropManager
{
    private static DropManager    _instance  ;
    public  static DropManager  GetInstance()
    {
        if (   _instance == null)
               _instance =  new DropManager();
        return _instance                     ;
    }

    private        DropManager()
    {

    }

    public List<SoulOrCoin    > @CoinList { get; set; } = [];
    public List<ElementalToken> TokenList { get; set; } = [];
}
