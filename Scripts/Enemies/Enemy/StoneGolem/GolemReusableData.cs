using System.Collections.Generic;
using UnityEngine;

public static class GolemReusableData
{
    public static int Health;
    public static int Shield;
    public static int CurrentAttack;
    public static int CurrentDamReceive;
    public static bool IsRight;
    public static bool IsAttackEnd;
    public static float TimeStartCurrentState;
    public static float TimeEndStateBefore;

    public static float IsWallFront;

    public static bool IsLaserEnd = true;

    public static List<GolemStateEnum> Moveset;
    public static int MoveCount;
}