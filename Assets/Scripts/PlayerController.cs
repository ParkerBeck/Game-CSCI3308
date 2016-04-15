using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float movementPower;
    public float jumpPower;
    public float airJumpPower;
    public int jumpCount;

    public float maxSpeed;

    int jumpsLeft;
    bool facingRight = true;
    Animator anim;

    private Rigidbody2D rb2d;
    private PolygonCollider2D collider;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        //transform = gameObject.GetComponent<Transform> ();
        collider = gameObject.GetComponent<PolygonCollider2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorziontal = Input.GetAxis("Horizontal");
        rb2d.AddForce(moveHorziontal * movementPower * Vector2.right, ForceMode2D.Impulse);
        anim.SetBool("Movin", moveHorziontal != 0);

        // this code is so we can face different directions
        if (moveHorziontal < 0 && facingRight)
        {
            flip();
        }
        else if (moveHorziontal > 0 && !facingRight)
        {
            flip();
        }

        if (onGround())
        {
            jumpsLeft = jumpCount;
        }

        //Should single jump if up is held down, double jump only while up is triggered
        if (jumpsLeft == jumpCount && Input.GetKey(KeyCode.UpArrow))
        {
            jump();
        }
        else if (jumpsLeft > 0 && Input.GetKeyDown(KeyCode.UpArrow))
        {
            jump(true);
        }

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }
    }

    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void jump(bool inAir = false)
    {
        if (!inAir)
        {
            rb2d.AddForce(Vector2.up * jumpPower);
        }
        else
        {
            rb2d.AddForce(Vector2.up * airJumpPower);
        }
        jumpsLeft--;
    }

    bool onGround()
    {
        //Terain is on 9th layer
        int terrainMask = 1 << 9;
        //Returns true if the player has terrain under
        return Physics2D.Raycast(transform.position, Vector2.down, collider.bounds.extents.y + .05f, terrainMask);
    }
}