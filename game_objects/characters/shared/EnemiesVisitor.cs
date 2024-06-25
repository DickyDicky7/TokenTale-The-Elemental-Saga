using Godot;

namespace TokenTaleTheElementalSaga;

//Visitor pattern: abstract visitor
[Tool       ]
[GlobalClass]
public abstract partial class EnemiesVisitor : Resource
{
    public abstract void Init();
    public abstract void Visit(MetalMonster metalMonster);
    public abstract void Visit(Imp          imp         );
    public abstract void Visit(KoboldPriest koboldPriest);
    public abstract void Visit(Cyclops      cyclops     );
    public abstract void Visit(RatfolkMage  ratfolkMage );
    public abstract void Visit(Bat          bat         );
    public abstract void Visit(HealTotem    healTotem   );
    public abstract void Visit(Ghost        ghost       );
    public abstract void Visit(Minotaur     minotaur    );
    public abstract void Visit(Cat          cat         );
    public abstract void Visit(Skeleton     skeleton    );
}
