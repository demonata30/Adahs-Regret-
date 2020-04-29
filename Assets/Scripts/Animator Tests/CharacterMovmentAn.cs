using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovmentAn : MonoBehaviour
{
    #region VARIABLES
    
    [Header("Referenced Variables")]
    [SerializeField]
    float speed;
    [SerializeField]
    KeyCode jumpingKey;
    [SerializeField]
    float jumpingValue;
    [SerializeField]
    LayerMask groundMask;

    [Header("RelatedScripts")]
    [SerializeField]
    CharacterAnimationsAn characterAnimationScript;

    [Header("Compontents")]
    Rigidbody2D rb;

    [Header("localVariables")]
    float characterHeight = 24f;
    bool canJump;
    bool isJumpresterected;

    #endregion
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        canJump = false;
        isJumpresterected = false;
    }
    #region UNITY CALLBACKS
    private void Update()
    {
        CheckHorizontalMovment();
        CheckJump();
        CheckCharacterFloating();
    }
    #endregion

    #region PRiVATE METHODS
    private void CheckHorizontalMovment()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            if(canJump)
                characterAnimationScript.SetRunning(true);
            
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                MoveRight();
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                MoveLeft();
            }
        }
        else
        {
            characterAnimationScript.SetRunning(false);
        }
    }
    private void MoveRight()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 180, 0);
        transform.position += Vector3.right * speed * Time.deltaTime;
    }
    private void MoveLeft()
    {
        gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
    private void CheckJump()
    {
        canJump = Physics2D.Raycast(transform.position, Vector2.down , characterHeight, groundMask);
        if (Input.GetKeyDown(jumpingKey) && canJump && !isJumpresterected)
        {
            //removes any force on y axis before jumping
            rb.velocity = new Vector2(rb.velocity.x, 0);
            characterAnimationScript.SetTakeOff(true);
            rb.AddForce(Vector2.up * jumpingValue, ForceMode2D.Impulse);
        }
    }
    private void CheckCharacterFloating()
    {
        // character is getting down
        if (rb.velocity.y == 0)
        {
            //making the velocity increase when the character is falling ( not to make the weird floating behaviour ) 
            //rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplyer * Time.deltaTime;
            rb.gravityScale = 1;
            characterAnimationScript.FalingDown(false);
        }
        else if (rb.velocity.y > 0)
        {
            rb.gravityScale = 2.5f;
        }
        else
        {
            rb.gravityScale = 3.5f;
            characterAnimationScript.FalingDown(true);
        }
    }
    // shows the length of the raycast to be accurate
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * characterHeight);
    }
    #endregion

    #region Courotines
    // use when you want to stop character from jumping for a while
    IEnumerator jumpRestrection(int waitTime)
    {
        isJumpresterected = true;
        yield return new WaitForSeconds(waitTime);
        isJumpresterected = false;
    }
    #endregion
}
