using Godot;
using Godot.Collections;
using System           ;

namespace TokenTaleTheElementalSaga;

[GlobalClass]
public sealed partial class Helper : GodotObject
{
    private Helper() : base()
    {

    }

    private static Helper _instance;
    public  static Helper GetInstance()
    {
        if    (_instance == null)
               _instance =  new();
        return _instance;
    }

    public static float StandardizeDegree(float degree)
    {
        if   ( degree  <  0 )
        {
               degree *= -1 ;
               degree %= 360;
               degree  = 360 - degree;
        }
        else
               degree %= 360;
        return degree       ;
    }

    public static float StandardizeRadian(float radian)
    {
        if   ( radian  <  0 )
        {
               radian *= -1;
               radian %= (2 * Mathf.Pi);
               radian  = (2 * Mathf.Pi) - radian;
        }
        else
               radian %= (2 * Mathf.Pi);
        return radian;
    }

    public  static float Clamp_StandardAngle(float angle, float minAngle, float maxAngle)
    {
        if (maxAngle
        >=  minAngle)
            return Mathf.Clamp(    angle
                              , minAngle
                              , maxAngle );
        else
        {
            if (angle < minAngle
            &&  angle > maxAngle)
            {
                if (minAngle - angle <= angle - maxAngle)
                    return  minAngle;
                else
                    return  maxAngle;
            }
            else
            {
                return angle;
            }
        }
    }

    public static Vector3 ProjectVector3ToPlane(Vector3 source, Vector3 planeNormal)
    {
float                                      dotProduct = source.Dot(     planeNormal     );
        Vector3 projectedVector = source - dotProduct *                 planeNormal      ;
        return  projectedVector;
    }

    public static Array<Vector3> CalculateMoveDirectionList(Vector3 mainVector, float priorityAngle)
    {
        mainVector.Normalized();
                  Array<Vector3> vector3List = [];
        //define posible direction
        float  deltaAngle = 0  ;
        while (deltaAngle < 2  *  Mathf.Pi)
        {
            float tempX = Mathf.Cos(deltaAngle) * mainVector.X - Mathf.Sin(deltaAngle) * mainVector.Z;
            float tempZ = Mathf.Sin(deltaAngle) * mainVector.X + Mathf.Cos(deltaAngle) * mainVector.Z;
            vector3List.Add(new Vector3(tempX, 0, tempZ).Normalized());
               deltaAngle    +=   Mathf.Pi 
                                       /10;
        }
        priorityAngle = Mathf.Cos(StandardizeRadian(
        priorityAngle            )                 );
        //priority sort
        for     (int i = 0    ; i < vector3List.Count - 1; i++)
        {
            int highestPriorityIndex  = i;
            for (int j = i + 1; j < vector3List.Count    ; j++)
            {
                if (Mathf.Abs(mainVector.Dot(vector3List[  j                 ]) - priorityAngle)
                 <  Mathf.Abs(mainVector.Dot(vector3List[highestPriorityIndex]) - priorityAngle))
                {
                highestPriorityIndex  = j;
                }
            }
            if (highestPriorityIndex != i)
            {
                Vector3 temp
          = new Vector3(vector3List[highestPriorityIndex].X ,
          0                                                 ,
                        vector3List[highestPriorityIndex].Z);
                vector3List[highestPriorityIndex] = new Vector3(vector3List[i].X ,
                                                                            0    ,
                                                                vector3List[i].Z);
                vector3List[ i                  ] = new Vector3(temp.X ,
                                                                temp.Y ,
                                                                temp.Z);
            }
        }
        return  vector3List;
    }

    public static Array<Vector3> CalculateTeleportDestinationList(Vector3 mainVector, Vector3 targetPosition)
    {
                  Array<Vector3> vector3List = [];
        //define angle
        float  deltaAngle = 0 ;
        while (deltaAngle < 2 * Mathf.Pi)
        {
            float tempX = Mathf.Cos(deltaAngle) * mainVector.X - Mathf.Sin(deltaAngle) * mainVector.Z;
            float tempZ = Mathf.Sin(deltaAngle) * mainVector.X + Mathf.Cos(deltaAngle) * mainVector.Z;
            vector3List.Add(new Vector3(tempX  ,
                                            0  ,
                                        tempZ));
               deltaAngle  +=   Mathf.Pi
                                     /10;
        }
        //sort
        float
priorityAngle = Mathf.Pi ;
        for     (int i = 0    ; i < vector3List.Count - 1; i++)
        {
            int highestPriorityIndex  = i;
            for (int j = i + 1; j < vector3List.Count    ; j++)
            {
                if (Mathf.Abs(mainVector.Dot(vector3List[  j                 ]) - priorityAngle)
                 <  Mathf.Abs(mainVector.Dot(vector3List[highestPriorityIndex]) - priorityAngle))
                {
                highestPriorityIndex  = j;
                }
            }
            if (highestPriorityIndex != i)
            {
                Vector3 temp
          = new Vector3(vector3List[highestPriorityIndex].X ,
          0                                                 ,
                        vector3List[highestPriorityIndex].Z);
                vector3List[highestPriorityIndex] = new Vector3(vector3List[i].X ,
                                                                            0    ,
                                                                vector3List[i].Z);
                vector3List[ i                  ] = new Vector3(temp.X ,
                                                                temp.Y ,
                                                                temp.Z);
            }
        }
        //define location
        for (int i = 0;
                 i < vector3List.Count; i++)
        {
                     vector3List
                [i]                      += targetPosition ;
        }
        return       vector3List;
    }

    public static Vector3 CalculateMoveDestination(
                  Vector3 currentPosition         ,
                  float          distance         ,
            Array<Vector3>       directionList    )
    {
        Vector3 finalDestination = new
        Vector3(0.0f, 0.0f, 0.0f);
        RandomNumberGenerator rand
  = new RandomNumberGenerator  ();
        int  luckyNumber =    rand                                              .RandiRange(0 , 4);
                finalDestination = currentPosition + directionList[luckyNumber] * distance        ;
        return  finalDestination ;
    }

    public static bool SuccessBaseOnRate(float successfulRate)
    {
                  successfulRate  =
(float)Math.Round(successfulRate, 2);
        if (successfulRate <= 0)
            return  false;
        else
        if (successfulRate >= 1)
            return !false;
        else
        {
            RandomNumberGenerator rand
      = new RandomNumberGenerator();
            float temp =        rand.Randf(       );
                  temp = (float)Math.Round(temp, 2);
            if (  temp <= successfulRate  )
                return !false;
            else
                return  false;
        }
    }
}






