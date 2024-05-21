using Godot;
using System;
namespace TokenTaleTheElementalSaga;
//CHAIN OF RESPONSIBILITY
public abstract partial class BaseDH : DamageHandler
{
	protected DamageHandler NextHandler { get; private set; }
	public void SetNextHandler(DamageHandler NextHandler)
	{
		this.NextHandler = NextHandler;
	}
	public abstract void ProcessDamage(float Damage);
}
