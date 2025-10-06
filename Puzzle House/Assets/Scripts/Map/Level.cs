using System.Collections.Generic;
using UnityEngine;

public static class Level
{
    public static float Height = 500;
    public static float Width = 500;

    public static float Scale = 1.0f;
    public static float IconScale = .1f;
    public static float Padding = .01f;

    public static Sprite UnexploredRoomIcon;
    public static Sprite DefaultRoomIcon;
    public static Sprite CurrentRoomIcon;
    public static Sprite SecretRoomIcon;
    public static Sprite PuzzleRoomIcon;
    
    public static Room CurrentRoom;
    public static Room PreviousRoom;

    public static List<Room> AllRooms = new List<Room>();

}
