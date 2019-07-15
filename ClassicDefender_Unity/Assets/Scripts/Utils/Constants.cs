using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants
{
    //Joystick
    public static float JOYSTICK_SENSITICITY = 0.5f;

    //LevelWraps
    public static float MIN_POSITION = -0.025f;
    public static float MAX_POSITION = 1.025f;

    //Projectile
    public static float PROJECTILE_TO_LIVE = 2f;
    public static float MISSILE_TO_LIVE = 10f;

    //Backgrounds
    public static float BACKGROUND_SPEED_FORWARD = 5f;
    public static float BACKGROUND_SPEED_BACK = 0.5f;
    public static float BACKGROUND_DIVISOR = 100;

    //WeaponButtons
    public static float SHOT_CAST_TIME = 6f;
    public static float MISSILE_CAST_TIME = 3f;

    //Weapons
    public static float BONUS_SHOT_DURATION = 3f;
    
    //Game objs ID
    public static int STAR_ID = 103001;
}