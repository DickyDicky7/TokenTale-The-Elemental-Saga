using Godot;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TokenTaleTheElementalSaga;

public partial class MetalMonster : ElementalMonster
{
	private int Charge { get; set; } = 0;
    public override void Attack(MainCharacter targetMainCharacter)
    {
		this.CauseDamage(targetMainCharacter);
	}
	public override void PlayAbilityAnimation(MainCharacter targetMainCharacter)
	{
		
		
	}
	public void AcceptVisitor(MonsterAbilityDispatchVisitor visitor)
	{
		visitor.VisitMetalMonster(this);
	}
	public override void _Ready()
	{
		base._Ready();
		this.Key = "Electric01";
	}
}
