using Godot;

namespace TokenTaleTheElementalSaga;

public partial class
           ElementalReactionDH
                      : BaseDH
{
    public Global.Element PassiveElement { get; private set; }
    public Global.Element @ActiveElement { get; private set; }
    public bool IsElementMonster { get; private set; }
    
    public ElementalReactionDH          (
           Global.Element passiveElement,
           Global.Element @activeElement,
           bool isElementMosnter        )
    {
        this.PassiveElement   = passiveElement  ;
        this.@ActiveElement   = @activeElement  ;
        this.IsElementMonster = isElementMosnter;
    }

    public override void ProcessDamage(ref float damage)
    {
        Global.ReactionType reactionType = DecideReaction(this.PassiveElement ,
                                                          this.@ActiveElement);
        
       RandomNumberGenerator
       rand = new();
        
        if (IsElementMonster)
        {
            switch (reactionType)
            {
                case Global.ReactionType.Risk   :
                    damage = 0;
                    break;
                case Global.ReactionType.Warning:
                    damage = (rand.RandfRange(0.3f, 0.7f)) * damage;
                    break;
                case Global.ReactionType.Buff   :
                    damage = (rand.RandfRange(1.3f, 1.5f)) * damage;
                    break;
                default:
                    //nothing happened
                    break;
            }
        }
        else
        {
            switch (reactionType)
            {
                case Global.ReactionType.Warning:
                    damage = (rand.RandfRange(1.1f, 1.3f)) * damage;
                    break;
                case Global.ReactionType.Buff   :
                    damage = (rand.RandfRange(1.4f, 1.6f)) * damage;
                    break;
                default:
                    //nothing happened
                    break;
            }
        }
        if (this.NextHandler is not null  )
                 NextHandler.ProcessDamage(ref damage);
    }
    public static Global.ReactionType DecideReaction(
        Global.Element passive                      ,
        Global.Element @active                      )
    {
        return ElementalReactionTable.GetInstance().ReactionTable[(int)passive][(int)active];
    }
}
