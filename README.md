# TOKENTALE-THE-ELEMENTAL-SAGA

## Youtube:
- Enemy AI with Behavior Trees - with Demo in Godot Engine
- Behavior Trees - Godot Game Dev (BETTER AUDIO)
- Godot 4.1: Behavior Trees with Beehave: rant and how to start using them..
- State machines and state charts in Godot

## Plugins:
- https://bitbra.in/beehave/#/ (https://github.com/bitbrain/beehave)
- https://github.com/derkork/godot-statecharts
- https://phantom-camera.dev/
- https://github.com/arkology/ShaderV
- https://github.com/DigvijaysinhGohil/Godot-Shader-Lib/

## Patterns:
- Behavior Tree
- State Machine
- Component
- Command

## Coding Convention:
- Private Fields' name, e.g:
```c#
private int _walkingSpeed = 100;
```
- Public Properties' name, e.g:
```c#
public int WalkingSpeed { get; set; } = 100;
```
- Classes' & Functions' name, e.g:
```c#
public partial class Adventurer
{
    public void Attack()
    {
        /* ... */
    }

    /* ... */
}
```
- Parameters' & Local Variables' name, e.g:
```c#
public partial class Adventurer
{
    public void Attack(Enemy _enemy_)
    {
        Enemy enemy = _enemy_;
        /* ... */
    }

    /* ... */
}
```

## Others:
- https://github.com/godotengine/awesome-godot
