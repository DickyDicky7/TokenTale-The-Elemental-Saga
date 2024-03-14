using Godot;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public sealed partial class MainCharacterTracesManagerSingleton   : List<Vector2>
{
              private       MainCharacterTracesManagerSingleton() : base()
    {

    }

    private static MainCharacterTracesManagerSingleton _instance;
    public  static MainCharacterTracesManagerSingleton  Instance
    {
        get => _instance ??= new();
    }


}
