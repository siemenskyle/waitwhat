using UnityEngine;
using System.Collections;

public class ShieldEnemy : MeleeEnemy
{

    // Constants
    private const float MOVE_SPEED = 0.1f;
    private const float WIND_UP_TIME = 0.75f;
    private const int TICKS_TO_UPDATE = 5;

    protected new void Start()
    {
        base.Start();
        moveSpeed = MOVE_SPEED;
        windUpTime = WIND_UP_TIME;
        ticksToUpdate = TICKS_TO_UPDATE;
        setReflective(true);
    }

    protected new void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
