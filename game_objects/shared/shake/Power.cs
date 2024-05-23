using Godot;

namespace TokenTaleTheElementalSaga  ;

public enum
Degree  { Linear, Quadratic, Cubic, };

internal static class Power
{
internal static float Evaluate(float @value, Degree @degree)
    {
         return @degree switch
         {
                 Degree.Linear    => @value                  ,
                 Degree.Quadratic => @value * @value         ,
                 Degree.    Cubic => @value * @value * @value,
                 _                => @value                  ,
         };
    }
}









