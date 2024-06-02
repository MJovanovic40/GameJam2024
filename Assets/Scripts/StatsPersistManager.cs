using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsPersistManager : MonoBehaviour
{
    public static int health = 100;
    public static int stamina = 100;
    public static string name = "Cico";
    public static float money = 3000.0f;
    public static Player.PlayerState currentState = Player.PlayerState.Inactive;
    public static bool hasGf = false;
    public static int examPrepPercent = 0;
}
