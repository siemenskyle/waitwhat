using UnityEngine;
using System.Collections;

public class SpearEnemy : MeleeEnemy {

    // Constants
    private const float MOVE_SPEED = 0.1f;
    private const float WIND_UP_TIME = 0.75f;
    private const int TICKS_TO_UPDATE = 5;

    public void OnCollisionEnter2D(Collider2D other)
    {
        // If this spear enemy hits a player, then kill the player.
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Human>().die();
        }
    }

    protected new void Start()
    {
        base.Start();
        moveSpeed = MOVE_SPEED;
        windUpTime = WIND_UP_TIME;
        ticksToUpdate = TICKS_TO_UPDATE;
    }
}
