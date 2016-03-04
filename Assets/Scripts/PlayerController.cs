using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpPower;

    private Rigidbody2D rb2d;
    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float moveHorziontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");
        rb2d.AddForce((Vector2.right * speed) * moveHorziontal);
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			if (rb2d.velocity.y <= .2 && rb2d.velocity.y >= -.2) {
				rb2d.AddForce ((Vector2.up * jumpPower));
			}
		}
    }
}
