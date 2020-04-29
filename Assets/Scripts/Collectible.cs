using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int value;
    
    public void OnCollected(GameObject actor)
    {
        actor.GetComponent<Player>().collectibles += value;
        actor.GetComponent<Player>().UpdatecollectiblesText();

        //Dissolve animation

        Destroy(this.gameObject);
    }
}
