using Godot;
using Godot.Collections;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Schema;

namespace TokenTaleTheElementalSaga;
[GlobalClass]
public sealed partial class Helper : GodotObject
{
	private Helper() : base()
	{

	}
	private static Helper _instance;
	public static Helper GetInstance()
	{
		if (_instance == null)
			_instance = new();
		return _instance;
	}
	public float StandardizeDegree(float degree)
	{
		if (degree < 0)
		{
			degree *= -1;
			degree %= 360;
			degree = 360 - degree;
		}
		else
			degree %= 360;
		return degree;
	}
	
	public float StandardizeRadian(float radian)
	{
		if (radian < 0)
		{
			radian *= -1;
			radian %= (2 * Mathf.Pi);
			radian = (2 * Mathf.Pi) - radian;
		}
		else
			radian %= (2 * Mathf.Pi);
		return radian;
	}
	public float Clamp_StandardAngle(float angle, float minAngle, float maxAngle)
	{
		if (maxAngle >= minAngle)
			return Mathf.Clamp(angle, minAngle, maxAngle);
		else
		{
			if (angle < minAngle && angle > maxAngle)
			{
				if (minAngle - angle <= angle - maxAngle)
					return minAngle;
				else
					return maxAngle;
			}
			else
			{
				return angle;
			}
		}
	}
	public Vector3 ProjectVector3ToPlane(Vector3 source, Vector3 planeNormal)
	{
		float dotProduct = source.Dot(planeNormal);
		Vector3 projectedVector = source - dotProduct * planeNormal;
		return projectedVector;
	}

	public Array<Vector3> PossibleAngleToMoveWithPriority(Vector3 mainAngle, float priorityAngle, bool priorityClockwise)
	{
		mainAngle.Normalized();
		Array<Vector3> vector3List = new();
		float deltaAngle;
		//define posible direction
		if (priorityClockwise == true)
		{
			deltaAngle = 0;
			while (deltaAngle < 2 * Mathf.Pi)
			{
				float tempX = Mathf.Cos(deltaAngle) * mainAngle.X - Mathf.Sin(deltaAngle) * mainAngle.Z;
				float tempZ = Mathf.Sin(deltaAngle) * mainAngle.X + Mathf.Cos(deltaAngle) * mainAngle.Z;
				vector3List.Add(new Vector3(tempX, 0, tempZ).Normalized());
				deltaAngle += Mathf.Pi / 10;
			}
		}
		else
		{
			deltaAngle = 2 * Mathf.Pi;
			while(deltaAngle > 0)
			{
				float tempX = Mathf.Cos(deltaAngle) * mainAngle.X - Mathf.Sin(deltaAngle) * mainAngle.Z;
				float tempZ = Mathf.Sin(deltaAngle) * mainAngle.X + Mathf.Cos(deltaAngle) * mainAngle.Z;
				vector3List.Add(new Vector3(tempX, 0, tempZ).Normalized());
				deltaAngle -= Mathf.Pi / 10;
			}
		}
		priorityAngle = Mathf.Cos(StandardizeRadian(priorityAngle));
		//priority sort
		for (int i = 0; i < vector3List.Count - 1; i++)
		{
			int highestPriorityIndex = i;
			for (int j = i + 1; j < vector3List.Count; j++)
			{
				if (Mathf.Abs(mainAngle.Dot(vector3List[j]) - priorityAngle) 
					< Mathf.Abs(mainAngle.Dot(vector3List[highestPriorityIndex]) - priorityAngle))
				{
					highestPriorityIndex = j;
				}
			}
			if (highestPriorityIndex != i)
			{
				Vector3 temp = new Vector3(vector3List[highestPriorityIndex].X, 0,vector3List[highestPriorityIndex].Z);
				vector3List[highestPriorityIndex] = new Vector3(vector3List[i].X, 0,vector3List[i].Z);
				vector3List[i] = new Vector3(temp.X, temp.Y, temp.Z);
			}
		}
		return vector3List;
	}
}
