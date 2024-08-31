using Godot                     ;
using System.Collections.Generic;

namespace TokenTaleTheElementalSaga;

public partial class  MonsterStats :  Resource
{
    private static    MonsterStats   _instance;
    public  static    MonsterStats GetInstance()
    {
        if (   _instance == null   )
        {
               _instance =
                  new MonsterStats();
        }
        return _instance;
    }

    private MonsterStats() : base()
    {
        Monster.Add("Fire01",
                     Fire01);
        Monster.Add("Water01",
                     Water01);
        Monster.Add("Wind01",
                     Wind01);
        Monster.Add("Ice01",
                     Ice01);
        Monster.Add("Electric01",
                     Electric01);
        Monster.Add("Earth01",
                     Earth01);
        Monster.Add("Wood01",
                     Wood01);
        Monster.Add("Haunt" , Haunt );
        Monster.Add("Tanker", Tanker);
        Monster.Add("Undead", Undead);
        Monster.Add("Thief" , Thief );

        Difficulty.Add(Global.Difficulty.Beginner  , new Record.DifficultyScale
        { MonsterBaseDamageRatio = 1.0f, MonsterMaxHealthRatio = 1.0f });
        Difficulty.Add(Global.Difficulty.Explorer  , new Record.DifficultyScale
        { MonsterBaseDamageRatio = 2.0f, MonsterMaxHealthRatio = 2.0f });
        Difficulty.Add(Global.Difficulty.Survivor  , new Record.DifficultyScale
        { MonsterBaseDamageRatio = 3.0f, MonsterMaxHealthRatio = 3.0f });
        Difficulty.Add(Global.Difficulty.Challenger, new Record.DifficultyScale
        { MonsterBaseDamageRatio = 7.0f, MonsterMaxHealthRatio = 7.0f });
    }

    public Dictionary<Global.Difficulty, Record.DifficultyScale> Difficulty { get; private set; } = [];
    public Dictionary<string           , Record.MonsterInfo    > Monster    { get; private set; } = [];
    private Record.MonsterInfo Fire01     { get; set; }
      = new Record.MonsterInfo { BaseDamage = 20, BaseMaxHealth = 30 , BaseMoveSpeed = 1.0f };
    private Record.MonsterInfo Water01    { get; set; }
      = new Record.MonsterInfo { BaseDamage = 10, BaseMaxHealth = 40 , BaseMoveSpeed = 1.0f };
    private Record.MonsterInfo Wind01     { get; set; }
      = new Record.MonsterInfo { BaseDamage = 7 , BaseMaxHealth = 40 , BaseMoveSpeed = 1.0f };
    private Record.MonsterInfo Ice01      { get; set; }
      = new Record.MonsterInfo { BaseDamage = 12, BaseMaxHealth = 50 , BaseMoveSpeed = 1.0f };
    private Record.MonsterInfo Electric01 { get; set; }
      = new Record.MonsterInfo { BaseDamage = 20, BaseMaxHealth = 60 , BaseMoveSpeed = 1.5f };
    private Record.MonsterInfo Earth01    { get; set; }
      = new Record.MonsterInfo { BaseDamage = 30, BaseMaxHealth = 80 , BaseMoveSpeed = 0.0f };
    private Record.MonsterInfo Wood01     { get; set; }
      = new Record.MonsterInfo { BaseDamage = 15, BaseMaxHealth = 30 , BaseMoveSpeed = 1.5f };
    private Record.MonsterInfo Haunt      { get; set; }
      = new Record.MonsterInfo { BaseDamage = 0 , BaseMaxHealth = 1  , BaseMoveSpeed = 1.5f };
    private Record.MonsterInfo Tanker     { get; set; }
      = new Record.MonsterInfo { BaseDamage = 10, BaseMaxHealth = 150, BaseMoveSpeed = 0.5f };
    private Record.MonsterInfo Undead     { get; set; }
      = new Record.MonsterInfo { BaseDamage = 8 , BaseMaxHealth = 20 , BaseMoveSpeed = 1.0f };
    private Record.MonsterInfo Thief      { get; set; }
      = new Record.MonsterInfo { BaseDamage = 0 , BaseMaxHealth = 20 , BaseMoveSpeed = 1.5f };
}
