using @Godot                    ;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga ;

public partial class EquipmentStats :  Resource
{
    private static   EquipmentStats   _instance;
    public  static   EquipmentStats GetInstance()
    {
        if   ( _instance == null )
               _instance =
        new EquipmentStats();
        return _instance    ;
    }

    private EquipmentStats() : base()
    {
        QuiverStats.Add(0, new Record.QuiverInfo { MaxArrow = 15, UpgradeCost = 000 });
        QuiverStats.Add(1, new Record.QuiverInfo { MaxArrow = 30, UpgradeCost = 050 });
        QuiverStats.Add(2, new Record.QuiverInfo { MaxArrow = 45, UpgradeCost = 090 });
        QuiverStats.Add(3, new Record.QuiverInfo { MaxArrow = 60, UpgradeCost = 140 });
        QuiverStats.Add(4, new Record.QuiverInfo { MaxArrow = 75, UpgradeCost = 200 });

        BootStats.Add(0, new Record.BootInfo { Speed = 0.75f, UpgradeCost = 000 });
        BootStats.Add(1, new Record.BootInfo { Speed = 1.25f, UpgradeCost = 100 });
        BootStats.Add(2, new Record.BootInfo { Speed = 1.50f, UpgradeCost = 200 });

        PowerUpsGeneratorStats.Add(0, new Record.PowerUpsGeneratorInfo { MaxUses = 1, UpgradeCost = 100 });
        PowerUpsGeneratorStats.Add(1, new Record.PowerUpsGeneratorInfo { MaxUses = 2, UpgradeCost = 200 });
        PowerUpsGeneratorStats.Add(2, new Record.PowerUpsGeneratorInfo { MaxUses = 3, UpgradeCost = 300 });
        PowerUpsGeneratorStats.Add(3, new Record.PowerUpsGeneratorInfo { MaxUses = 4, UpgradeCost = 400 });
    }

    public Dictionary<int, Record.           QuiverInfo>            QuiverStats { get; private set; } = [];
    public Dictionary<int, Record.             BootInfo>              BootStats { get; private set; } = [];
    public Dictionary<int, Record.PowerUpsGeneratorInfo> PowerUpsGeneratorStats { get; private set; } = [];

}
