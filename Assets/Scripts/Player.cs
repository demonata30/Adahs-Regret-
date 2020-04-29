using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static GameObject player;
    public Vector2 spawnPos;

    [Header("Properties")]
    public int collectibles = 0;

    [Header("UI")]
    public TextMeshProUGUI txt_collectibles;

    private void Start()
    {
        player = this.gameObject;
        player.transform.position = spawnPos;

        print("Screen dimensions in world space: " + Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)));
    }

    private void Update()
    {
        if (player.transform.position.y < -4)
            Respawn();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Collectible")
        {
            other.GetComponent<Collectible>().OnCollected(this.gameObject);
        }
    }

    public void UpdatecollectiblesText()
    {
        txt_collectibles.text = collectibles.ToString();
    }

    private void Respawn()
    {

        foreach (WorldObject wrldObj in WorldGeneration.allWorldObjects)
        {
            if (wrldObj != null)
            {
                Destroy(wrldObj.gameObject);
                WorldGeneration.allWorldObjects.Remove(wrldObj);
            }
        }

        WorldGeneration.lastPlatformPosition = new Vector2(-3,0);
        WorldGeneration.startTime = Time.time;

        collectibles = 0;
        UpdatecollectiblesText();

        Camera.main.transform.position = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);

        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        player.transform.position = spawnPos;
    }
}
