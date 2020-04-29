using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObject : MonoBehaviour
{
    public static float movementSpeed = 1f;

    private void Update()
    {
        //if (this.transform.position.x <= Player.player.transform.position.x - WorldGeneration.screenWidth - 1)

        if (this.transform.position.x < (Time.time - WorldGeneration.startTime) * 2 - 3)
        {
            WorldGeneration.allWorldObjects.Remove(this);
            Destroy(this.gameObject);
        }
    }
}
