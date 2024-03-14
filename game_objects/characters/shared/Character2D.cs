using Godot;
using Godot.Collections;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public abstract partial class Character2D : CharacterBody2D
{
    //[Export(PropertyHint.NodeType)]
    //public FactoryParametersController2D ParametersController2D { get; set; }

    public Vector2 MovingDirection2D { get; set; }


}
