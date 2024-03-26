using Godot;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public sealed partial class SingletonMainCharacterTracesManager   : GodotObject
{
              private       SingletonMainCharacterTracesManager() : base()
    {

    }

    private static SingletonMainCharacterTracesManager   _instance;
    public  static SingletonMainCharacterTracesManager GetInstance()
    {
        return _instance ??= new();
    }


}
