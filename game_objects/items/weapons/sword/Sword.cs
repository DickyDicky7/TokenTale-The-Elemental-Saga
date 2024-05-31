using Godot;
using System.Collections.Generic;
using Aareaa3D         = Godot.
                                        Area3D;
using AnimationPlayerr = Godot.AnimationPlayer;

namespace TokenTaleTheElementalSaga;

public partial class Sword : Weapon
{
    [Export] public Sprite3D Sprite3D { get; set; }
    [Export] public Sprite3D Shadow3D { get; set; }
    [Export] public Aareaa3D Aareaa3D { get; set; }
    [Export] public CollisionShape3D CollisionShape3D { get; set; }

    [Export] public AnimatedSprite3D AnimatedSprite3D { get; set; }
    [Export] public AnimatedSprite3D AnimatedShadow3D { get; set; }

    [Export] public AnimationPlayerr AnimationPlayerr { get; set; }

    public int SlashCount { get; set; }
    public     Vector2
    DefaultOffsetSprite3D
    { get; private set; }
    public float Damage { get; set; }
    public Sword()
    {
        this.Upgradeable = true;
        this.Available = true;
        this.Level = -1;
        if (this.Available == true)
            this.Upgrade();
    }

    public override void _Ready()
    {
                    base._Ready();

        DefaultOffsetSprite3D = Sprite3D.Offset;
        this.CoolDownTimer.WaitTime = OwnerMainCharacter.BoosterManager.SwordCoolDown;
		//Load from saved ?
	}
	public override void Upgrade()
	{
		base.Upgrade();
        Dictionary<int, Record.SwordInfo> SwordStats
            = WeaponStats.GetInstance().SwordStats;
        if (this.Level == SwordStats.Count - 1)
            this.Upgradeable = false;
        this.Damage = SwordStats[Level].Damage;
        if (this.Upgradeable == true)
            this.NextLevelUpgradeCost = SwordStats[Level + 1].UpgradeCost;
        else
            this.NextLevelUpgradeCost = -1;
	}
}
