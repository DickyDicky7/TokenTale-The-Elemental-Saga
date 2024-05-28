using Godot;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace TokenTaleTheElementalSaga;

public partial class MetalMonster : ElementalMonster
{
	private int Charge { get; set; } = 0;
	private float StunDuration { get; set; } = 1.0f;
    public override void Attack(MainCharacter targetMainCharacter)
    {
		this.CreateAbility(nameof(MiniThunderShock) ,targetMainCharacter);
	}
	public override void AcceptVisitor(EnemiesVisitor visitor)
	{
		visitor.VisitMetalMonster(this);
	}
	public void Shock(MainCharacter targetMainCharacter)
	{
		if (this.Charge < 3)
		{
			Charge++;
		}
		else
		{
			this.Charge = 0;
			targetMainCharacter.StartStun(StunDuration);
		}
	}
	public override void _Ready()
	{
		this.Key = "Electric01";
		base._Ready();
	}
}
