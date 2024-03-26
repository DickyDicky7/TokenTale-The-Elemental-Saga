//using Godot;

//namespace TokenTaleTheElementalSaga;

//[GlobalClass]
//public abstract partial class Skill2D : Node2D, ISpawnable // Command
//{
//    [Export]
//    public SkillIcon2D SkillIcon { get; set; }
//    [Export]
//    public SkillSign2D SkillSign { get; set; }
//    [Export]
//    public SkillEntity2D SkillEntity2D { get; set; }

//    [Export]
//    public SpawnableDecider SpawnableDecider { get; set; }


//    public void Spawn(Marker2D @spawnerPivot, Vector2 @spawnGlobalPosition)
//    {
//        SkillEntity2D clone = (SkillEntity2D)SkillEntity2D.Duplicate();
//        bool spawnable = true;
//        if (SpawnableDecider != null)
//        {
//            spawnable = SpawnableDecider.IsGlobalPositionSpawnable(@spawnerPivot, @spawnGlobalPosition);
//        }
      
//        if (spawnable)
//        {
//            @spawnerPivot.GetTree().Root.AddChild(clone);

//        }
//    }
//}

