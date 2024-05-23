using Godot;
using System;
using System.Runtime.CompilerServices;
namespace TokenTaleTheElementalSaga;
[GlobalClass]
public partial class GameManager : Resource
{
	private static GameManager _instance;
	public static GameManager GetInstance()
	{
		if (_instance == null)
			_instance = new GameManager();
		return _instance;
	}
	public MonsterManager MonsterManager { get; private set; }
	public GameManager() : base()
	{
		this.MonsterManager = new MonsterManager();
	}
}
