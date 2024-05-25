﻿using Godot;
using Godot.Collections;
using System.Linq;

namespace TokenTaleTheElementalSaga;

public static class Extension
{
    public static void Clear(this Tween @tween)
    {
        if (@tween != null)
        {
            @tween.Stop();
            @tween.Kill();
            //@tween.Dispose();
        }
    }

    public static bool IsMousePressed(this InputEvent @inputEvent, MouseButton @buttonIndex)
    {
        return @inputEvent is not null
            && @inputEvent is
                InputEventMouseButton
                inputEventMouseButton
            &&  inputEventMouseButton.Pressed
            &&  inputEventMouseButton.ButtonIndex
            ==                       @buttonIndex;
    }

    public static Vector2 GetInputDirection()
    {
        return
        Input. GetVector ("L", "R", "U", "D");
    }

    public static bool IsZero(this Vector2 @vector2)
    {
        return @vector2 == Vector2.Zero;
    }

    public static bool IsZero(this Vector3 @vector3)
    {
        return @vector3 == Vector3.Zero;
    }

    public static void Insert(this Array<State>
        @activeComponentStates, State @newComponentState)
    {
        @activeComponentStates. Add  (@newComponentState);
    }

    public static bool IsKeyboardPressed(this InputEvent @inputEvent, Key @keycode)
    {
        return @inputEvent is not null
            && @inputEvent is
                InputEventKey
                inputEventKey
            &&  inputEventKey.Pressed
            &&  inputEventKey.Keycode
            ==               @keycode;
    }

    public static Vector3 ConvertToTopDown(this Vector2 @vector2)
    {
    return new(  @vector2.X, 0.0f, @vector2.Y  );
    }

    public static Vector2 ConvertToTopDown(this Vector3 @vector3)
    {
    return new(  @vector3.X,       @vector3.Z  );
    }

    public static Vector3 GetGlobalMousePosition(this Node3D @node_3D)
    {
        Viewport viewport = @node_3D.GetViewport();
        Camera3D camera3D = viewport.GetCamera3D();

        Vector2 mousePosition = viewport.GetMousePosition();
        float   rayyyLengthhh = 1000;
        Vector3 from =        camera3D.ProjectRayOrigin(screenPoint: mousePosition)                ;
        Vector3 tooo = from + camera3D.ProjectRayNormal(screenPoint: mousePosition) * rayyyLengthhh;
        PhysicsDirectSpaceState3D
        physicsDirectSpaceState =
                              camera3D.GetWorld3D().DirectSpaceState;
        PhysicsRayQueryParameters3D
        physicsRayQueryParameters     = new();
        physicsRayQueryParameters.From = from;
        physicsRayQueryParameters.To   = tooo;
        Dictionary      rayCastResult =
        physicsDirectSpaceState.IntersectRay(
        physicsRayQueryParameters           );

        GD.Print(rayCastResult.Keys.ToArray()[3].GetType());

        if     (        rayCastResult.ContainsKey("position"))
        return (Vector3)rayCastResult            ["position"];
        else
        return
        @node_3D         .GetScreenMousePosition()
                         .ConvertToTopDown      ();
    }

    public static Vector3 Get_LocalMousePosition(this Node3D @node_3D)
    {
        Vector3 globalMousePosition = @node_3D.GetGlobalMousePosition();
        Vector3 @localMousePosition = @node_3D.  ToLocal             (
                globalMousePosition);
        return  @localMousePosition ;
    }

    public static Vector2 GetScreenMousePosition(this Node @node)
    {
        Viewport viewport = @node.GetViewport();
        return
        viewport.GetMousePosition() -
        viewport.       GetWindow() .
        Size / 2;
    }

    public static void LookAt______Camera(this Node3D @node3D, Camera3D @camera3D)
    {
        if (@camera3D is null)
        {
            return;
        }

        @node3D.Rotation =
        @node3D.Rotation with
        {
            X = @camera3D.Rotation.X,
            Y =   @node3D.Rotation.Y,
            Z =   @node3D.Rotation.Z, /*!*/
        };
    }

    public static void LookAtActiveCamera(this Node3D @node3D                    )
    {
        @node3D.       LookAt______Camera(
        @node3D.GetViewport()
               .GetCamera3D()            );
    }
}

