using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AnimationTags
{
    public const string KNOCK_DOWN = "KnockDown";
    public const string MOVEMENT = "Movement";
    public const string STAND_UP = "StandUp";

    public const string ATTACK1 = "Attack1";
    public const string ATTACK2 = "Attack2";
    public const string ATTACK3 = "Attack3";

    public const string PUNCH1 = "Punch1";
    public const string PUNCH2 = "Punch2";
    public const string PUNCH3 = "Punch3";

    public const string KICK1 = "Kick1";
    public const string KICK2 = "Kick2";

    public const string DEATH = "Death";
    public const string IDLE = "Idle";
    public const string HIT = "Hit";
}

public class ObjectTags
{
    public const string UNTAGGED = "Untagged";
    public const string CAMERA = "MainCamera";

    public const string RIGHT_LEG = "RightLeg";
    public const string LEFT_ARM = "LeftArm";
    public const string LEFT_LEG = "LeftLeg";

    public const string GROUND = "Ground";
    public const string HEALTH = "Health";

    public const string PLAYER = "Player";
    public const string ENEMY = "Enemy";
}

public class Axis
{
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
}
