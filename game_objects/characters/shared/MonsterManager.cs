using Godot;

     namespace TokenTaleTheElementalSaga;

public partial class   MonsterManager   : Resource
{
    public Record.DifficultyScale
           CurrentDifficulty
    {
                get;
        private set;
    } = new();
    
    public MonsterManager()
    {
           this.@CurrentDifficulty = MonsterStats.GetInstance().Difficulty[Global.Difficulty.Beginner];
    }
    
    public void IncreaseDifficulty           (
                @Global.Difficulty difficulty)
    {
           this.@CurrentDifficulty = MonsterStats.GetInstance().Difficulty[       difficulty         ];
    }
}
