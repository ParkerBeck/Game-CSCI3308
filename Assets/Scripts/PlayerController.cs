using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float movementPower;
    public float jumpPower;
    public float airJumpPower;
    public int jumpCount;
	private bool onGround; 
    public float maxSpeed;
	private GameObject Camera;

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
		Camera = GameObject.FindGameObjectWithTag ("MainCamera");
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

		if (onGround)
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

		if (rb2d.velocity.x < -maxSpeed)
		{
			rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
		}
		if (transform.position.x < (Camera.transform.position.x - 5)) {
			transform.position = new Vector3 (Camera.transform.position.x - 5, transform.position.y, transform.position.z);
			rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
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
			rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
        }
        else
        {
			rb2d.AddForce(Vector2.up * airJumpPower, ForceMode2D.Impulse);
        }
        jumpsLeft--;
    }
		
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Ter") {
			onGround = true;
		}
		print (col.gameObject.tag);
	}

	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "Ter") {
			onGround = false;
		}
	}
}
