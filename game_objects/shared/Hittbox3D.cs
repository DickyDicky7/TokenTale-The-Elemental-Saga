using Godot;
using System.Linq;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public partial class Hittbox3D : CustomArea3D
{
    public float EffectRadius { get; protected set; }
    public bool Hit { get; set; } = false;
    protected override void OnAreaEntered(Area3D @area3D)
    {
		this.Hit = true;
    }
	protected override void OnBodyEntered(Node3D @node3D)
	{
		this.Hit = true;
		if (this.GetParent() is Ability3D tempAbility && node3D is Character3D tempCharacter)
		{
			float damage = tempAbility.Caster.CalculateElementalDamage(tempAbility, tempCharacter);
			tempCharacter.CurrentHealth -= damage;
			tempCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
		}
		if (this.GetParent() is Weapon tempWeapon && node3D is Monster tempMonster)
		{
			float damage = tempWeapon.OwnerMainCharacter.CalculatePhysicsDamage(tempMonster);
			tempMonster.CurrentHealth -= damage;
			tempMonster.EmitSignal(Character3D.SignalName.HealthChange, damage);
		}
	}
	public override void _Ready()
	{
		base._Ready();
		this.StartWatching();
	}
}


