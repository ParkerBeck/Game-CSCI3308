using UnityEngine;
using System.Collections;

public class CollectibleController : MonoBehaviour {

	private int wtr;
	private bool collided;
	Animator anim;
	private BoxCollider2D boxCollider;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		boxCollider = GetComponent<BoxCollider2D> (); //not a rigidbody2d to avoid gravitational effects
		wtr = 0;
	}
	
	// Update is called once per frame
	void Update () {


		int playerMask = 1 << 4; //set to whatever layer player is on
		bool up = Physics2D.Raycast(transform.position, Vector2.up, GetComponent<Collider>().bounds.extents.y + .05f, playerMask);
		bool down = Physics2D.Raycast(transform.position, Vector2.down, GetComponent<Collider>().bounds.extents.y + .05f, playerMask);
		bool left = Physics2D.Raycast(transform.position, Vector2.left, GetComponent<Collider>().bounds.extents.y + .05f, playerMask);
		bool right = Physics2D.Raycast(transform.position, Vector2.right, GetComponent<Collider>().bounds.extents.y + .05f, playerMask);
		if (up || down || left || right) /// if player collides with collectible
		{
			collided = true;
		}
		if (collided) //waits 30 frames before expiring so an animation can play?
		{
			wtr++;
			//if (wtr == 30)
				//killself
		}
	}
}
