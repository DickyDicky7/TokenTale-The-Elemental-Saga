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
			float damage = tempAbility.Caster.CalculateDamage(tempAbility, tempCharacter);
			tempCharacter.CurrentHealth -= damage;
			tempCharacter.EmitSignal(Character3D.SignalName.HealthChange, damage);
		}
	}
}


