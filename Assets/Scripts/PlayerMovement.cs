using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static GameObject player;

    [Header("Components")]
    private Rigidbody2D rb;

    [Header("Properties")]
    public int jumpsAvailable;
    public int maxJumps = 1;
    public float maxVelocity;

    [Header("Speeds")]
    public float movementSpeed;
    public float jumpSpeed;

    public Vector3 cameraOffset = new Vector3(0, 0, -1.5f);

    private void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody2D>();

        jumpsAvailable = maxJumps;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        if (Input.GetAxisRaw("Horizontal") != 0 && Mathf.Abs(rb.velocity.x) < maxVelocity)
        {
            rb.AddForce(Input.GetAxisRaw("Horizontal") * Vector3.right * Time.deltaTime * movementSpeed);
        }
        else if(Mathf.Abs(rb.velocity.x) > 0)
        {
            ComeToStop();
        }

        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, Camera.main.transform.position.z), Time.deltaTime * 3);
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(player.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z), Time.deltaTime * 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Ground")
        {
            jumpsAvailable = maxJumps;
        }
    }

    private void Move(Vector2 playerInput)
    {
        rb.velocity = new Vector2(0, rb.velocity.y + playerInput.y);
    }

    private void Jump()
    {
        if (jumpsAvailable > 0)
        {
            jumpsAvailable--;

            rb.AddForce(Vector2.up * jumpSpeed);
        }
    }

    private void ComeToStop()
    {
        rb.AddForce(new Vector2(-rb.velocity.x, 0));
    }
}