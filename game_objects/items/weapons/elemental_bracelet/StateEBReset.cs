using     Godot                    ;

namespace TokenTaleTheElementalSaga;

public partial class  @StateEBReset: StateEB
{

    [Export]
    [ExportGroup("Transition ##")]
    public State CastState { get; set; }

    public override void _Enter()
    {
                    base._Enter()                         ;
                    this.ElementalBracelet.IsInUse = false;
    }

    public override void _Leave()
    {
                    base._Leave();
    }

    public override void _Input  (@InputEvent @event)
    {
                    base._Input  (            @event);
        if (@event.IsMousePressed(MouseButton.Right))
        {
            if (this.ElementalBracelet.IsCoolingDown                 == false
            &&  this.ElementalBracelet.OwnerMainCharacter.IsStunning == false
            &&  this.ElementalBracelet.    CurrentElement            != Global.Element.None)
                ChangeState(CastState);
        }
        if (@event
        is      InputEventKey
                inputEventKey        )
        {
            if (inputEventKey.Pressed)
            {
                if (this.ElementalBracelet.CurrentElement            != Global.Element.None
                &&  this.ElementalBracelet.CurrentEnergy             != 0                  )
                {
                    if (inputEventKey.Keycode == Key.P)
                    {
                        this.ElementalBracelet.  Store();
                    }
                }
                if (this.ElementalBracelet.CurrentElement            == Global.Element.None
                &&  this.ElementalBracelet.CurrentEnergy             == 0                  )
                {
                    if (inputEventKey.Keycode == Key.O)
                    {
                        this.ElementalBracelet.Retrive();
                    }
                }
            }
        }
    }
}
