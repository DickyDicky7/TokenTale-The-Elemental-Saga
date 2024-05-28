using Godot;
using System;
namespace TokenTaleTheElementalSaga;
public partial class MRootTrapHitbox : Hittbox3D
{
	protected override void OnBodyEntered(Node3D node3D)
	{
		base.OnBodyEntered(node3D);
		if (this.GetParent() is Ability3D tempAbility && node3D is MainCharacter tempMainCharacter)
		{
			Trap(tempAbility, tempMainCharacter);
		}
	}
	public override void _Ready()
	{
		base._Ready();
	}
	private void Trap (Ability3D ability, MainCharacter mainCharacter)
	{
		AnimationPlayer animationPlayer = ability.GetNode("AnimationPlayer") as AnimationPlayer;
		float timeLeft = (float)animationPlayer.CurrentAnimationLength
			- (float)animationPlayer.CurrentAnimationPosition;
		mainCharacter.StartSpeedEffect(0, timeLeft);
	}
}
