using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public GameObject bridgeCollider;

    public List<GameObject> pieces = new List<GameObject>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            OpenHole();
        }
    }

    private void OpenHole()
    {
        bridgeCollider.GetComponent<BoxCollider2D>().enabled = false;

        foreach(GameObject go in pieces)
        {
            go.GetComponent<Rigidbody2D>().gravityScale = 0.7f;
            go.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            go.layer = 8;
            go.GetComponent<Rigidbody2D>().AddForce(Random.insideUnitCircle.normalized * 10.5f);
        }
    }
}
