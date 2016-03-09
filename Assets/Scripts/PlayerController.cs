using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpPower;
	bool facingRight = true;
	Animator anim; 

    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorziontal = Input.GetAxis("Horizontal");
        rb2d.AddForce((Vector2.right * speed) * moveHorziontal);

		if (moveHorziontal == 0) {
			anim.SetBool ("Movin", false);
		}

		if (moveHorziontal != 0) {
			anim.SetBool ("Movin", true);
		}

		//anim.SetFloat("Speed", Mathf.Abs(moveHorziontal));

		// this code is so we can face different directions
		if (moveHorziontal < 0 && facingRight) {
			flip ();
		}
		else if (moveHorziontal > 0 && !facingRight) 
		{
			flip ();
		}

		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (rb2d.velocity.y <= .2 && rb2d.velocity.y >= -.2) {
				rb2d.AddForce ((Vector2.up * jumpPower));
			}
		}
    }

	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

}
