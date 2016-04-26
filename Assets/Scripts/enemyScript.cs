using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
	
	private Rigidbody2D rb2d;
	///Speed of the enemy
	public float enemySpeed;
	private float jmpTimer;
	private Vector3 plyrPos;
	bool facingRight = true;
	// Use this for initialization
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		enemySpeed = 5.0f;
		jmpTimer = 0.0f;
		rb2d.gravityScale = 2f;
	}
	
	///Enemy should travel towards the player.
	///This has to be FixedUpdate, on regular update, pauses break the enemies
	void FixedUpdate () {
		plyrPos = GameObject.FindGameObjectWithTag ("Player").transform.position;

		if(jmpTimer < 60.0f)
			jmpTimer++;
		
		if (plyrPos.x < transform.position.x && (transform.position.x - plyrPos.x) < 4) {
			rb2d.AddForce ((Vector2.right * enemySpeed) * -1);
			if (!facingRight) {
				flip ();
			}
		}

		if (plyrPos.x > transform.position.x && (transform.position.x - plyrPos.x) < 4) {
			rb2d.AddForce ((Vector2.right * enemySpeed) * 1);
			if (facingRight) {
				flip ();
			}
		}
		
		if (plyrPos.y > transform.position.y && jmpTimer == 60) {
			rb2d.AddForce ((Vector2.up * 3) * 50);
			jmpTimer = 0;
		}

		if (transform.position.y < -2.5) {
			//gameObject.SetActive(false);
			Destroy(gameObject);
		}
	
	}

	///Change the direction of the enemy, for animation purposes
	void flip()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
