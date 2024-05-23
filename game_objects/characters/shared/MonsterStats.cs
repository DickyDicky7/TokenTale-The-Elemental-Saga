using Godot;
using System;

public partial class MonsterStats : Resource
{
	private static MonsterStats _instance;
	public static MonsterStats GetInstance()
	{
		if (_instance == null)
		{
			_instance = new MonsterStats();
		}
		return _instance;
	}
	private MonsterStats() : base()
	{

	}
}
