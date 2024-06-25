using Godot ;
using System;

namespace TokenTaleTheElementalSaga;

public partial class Bat : ElementalMonster
{
    public override void Attack(MainCharacter targetMainCharacter)
    {
        CreateAbility(   nameof(MiniBlowWind),targetMainCharacter);
    }

    public override void AcceptVisitor(EnemiesVisitor visitor)
    {
        visitor.Visit(this);
    }

    public override
        void _Ready()
    {
        this.Key = "Wind01";
        base._Ready()      ;
    }
}
