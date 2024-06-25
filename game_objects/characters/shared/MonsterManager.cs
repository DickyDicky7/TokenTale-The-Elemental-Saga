using Godot;
using System;
using System.Security.Cryptography.X509Certificates;
namespace TokenTaleTheElementalSaga;
public partial class MonsterManager : Resource
{
	public Record.DifficultyScale CurrentDifficulty { get; private set; } = new();
	public MonsterManager()
	{
		CurrentDifficulty = MonsterStats.GetInstance().Difficulty[Global.Difficulty.Beginner];
	}
	public void IncreaseDifficulty(Global.Difficulty difficulty)
	{
		this.CurrentDifficulty = MonsterStats.GetInstance().Difficulty[difficulty];
	}
}
