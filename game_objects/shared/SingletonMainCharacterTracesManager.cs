using Godot;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public sealed partial class SingletonMainCharacterTracesManager   : List<Vector2>
{
              private       SingletonMainCharacterTracesManager() : base()
    {

    }

    private static SingletonMainCharacterTracesManager _instance;
    public  static SingletonMainCharacterTracesManager  Instance
    {
        get => _instance ??= new();
    }


}
