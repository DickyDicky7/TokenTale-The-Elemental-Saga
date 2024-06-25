using Godot;

namespace TokenTaleTheElementalSaga;

//CHAIN OF RESPONSIBILITY
public abstract partial class
       BaseDH : @DamageHandler
{
    protected   @DamageHandler
                   NextHandler
    {
                get;
        private set;
    } = null;

    public void SetNextHandler(DamageHandler nextHandler)
    {
           this.   NextHandler =             nextHandler;
    }

    public abstract void ProcessDamage(ref float damage);
}
