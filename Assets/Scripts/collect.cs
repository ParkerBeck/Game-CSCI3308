using UnityEngine;
using System.Collections;

public class collect : MonoBehaviour {
	private Rigidbody2D rb2d;
	private float pos;
	///Goes to next level on collision
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.FindGameObjectWithTag ("Score").SendMessage ("NextLevel");
		}
	}

	void Start(){
		pos = transform.position.y;
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}

	
	//Moves up and down
	void Update(){
		if (transform.position.y <= pos) {
			rb2d.AddForce ((Vector2.up * 50));
		}
		rb2d.velocity = new Vector2 (0, rb2d.velocity.y);
	}
}
