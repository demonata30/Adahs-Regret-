using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldGeneration : MonoBehaviour
{
    public static Vector2 lastPlatformPosition = new Vector2(-3,0);
    public int nextPlatformDistanceThreshold;

    public List<GameObject> platformPrefabs = new List<GameObject>();
    public GameObject collectiblePrefab;

    public static float screenHeight;
    public static float screenWidth;

    public static float startTime;

    public static List<WorldObject> allWorldObjects = new List<WorldObject>();

    private void Start()
    {
        screenHeight = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x;
        screenWidth = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).y;
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(Player.player.transform.position.x - lastPlatformPosition.x) < nextPlatformDistanceThreshold)
            GenerateNewPlatform();
    }

    public void GenerateNewPlatform()
    {
        Vector2 pos = NewPositionOffset(lastPlatformPosition);

        GameObject newPlatform = Instantiate(platformPrefabs[Random.Range(0, platformPrefabs.Count)], pos, Quaternion.identity);

        lastPlatformPosition = pos;

        allWorldObjects.Add(newPlatform.GetComponent<WorldObject>());

        //Collectible chance
        if(Random.Range(0, 2) == 0)
        {
            Instantiate(collectiblePrefab, (Vector2)newPlatform.transform.position + Vector2.up * 0.8f, Quaternion.identity, newPlatform.transform);
        }
    }

    private Vector2 NewPositionOffset(Vector2 lastPos)
    {
        if (lastPos.y > screenHeight - 3.2f)
        {
            lastPos -= Vector2.up;
            return NewPositionOffset(lastPos);
        }
        else if(lastPos.y < -screenHeight + 3.2f)
        {
            lastPos += Vector2.up;  
            return NewPositionOffset(lastPos);
        }
        else
        {
            return lastPos + new Vector2(Random.Range(2f, 3f), Random.Range(-0.5f, 0.5f));
        }
    }
}
