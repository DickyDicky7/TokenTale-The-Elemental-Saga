using Godot;
using System;
namespace TokenTaleTheElementalSaga;
//CHAIN OF RESPONSIBILITY
public partial interface DamageHandler
{
	public void ProcessDamage(float Damage);
}
