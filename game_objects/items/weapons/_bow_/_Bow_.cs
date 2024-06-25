using Godot;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace TokenTaleTheElementalSaga;

#pragma warning disable IDE1006 // Naming Styles
public partial class _Bow_ : Weapon
#pragma warning restore IDE1006 // Naming Styles
{
    [Export] public AnimationPlayer
                    AnimationPlayerr
    {
        get;
        set;
    }
    [Export] public AnimatedSprite3D AnimatedSprite3DMmainn { get; set; }
    [Export] public CollisionShape3D CollisionShape3D       { get; set; }
    [Export] public AnimatedSprite3D AnimatedSprite3DEffect { get; set; }
    [Signal]
    public delegate void ArrowChangedEventHandler(int newCurrentArrow);
    [Signal]
    public delegate void OutOfArrowEventHandler();

    public Vector2 CurrentRotationPosition { get; set; }

    //public override void _Ready()
    //{
    //                base._Ready();

    //    AnimatedSprite3DMmainn.LookAtActiveCamera();
    //    AnimatedSprite3DEffect.LookAtActiveCamera();
    //}
    public float Damage { get; set; } = default;
    public int CurrentArrow { get; set; }
    public _Bow_() : base()
    {
        this.Upgradeable = true;
        this.Available = true;
        this.Level = -1;
        if (this.Available == true && this.Upgradeable == true)
            this.Upgrade();
    }
	public override void _Ready()
	{
		base._Ready();
        this.CoolDownTimer.WaitTime = OwnerMainCharacter.BoosterManager.BowCoolDown;
        this.CurrentArrow = OwnerMainCharacter.EquipmentManager.Quiver.MaxArrow;
        this.OwnerMainCharacter.BoosterManager.BowScrollChanged += UpdateCoolDown;
        //Load from saved
	}
	public override void Upgrade()
	{
		base.Upgrade();
		Dictionary<int, Record.BowInfo> BowStats
			= WeaponStats.GetInstance().BowStats;
		if (this.Level == BowStats.Count - 1)
			this.Upgradeable = false;
		this.Damage = BowStats[Level].Damage;
		if (this.Upgradeable == true)
			this.NextLevelUpgradeCost = BowStats[Level + 1].UpgradeCost;
		else
			this.NextLevelUpgradeCost = -1;
        this.EmitSignal(Equipment.SignalName.JustUpgrade);
	}
    private void UpdateCoolDown(float newCooldown, float newBonusDamageRatio)
    {
        this.CoolDownTimer.WaitTime = newCooldown;
    }
}
