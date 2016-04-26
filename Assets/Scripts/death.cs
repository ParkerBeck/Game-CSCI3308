using UnityEngine;
using System.Collections;
public class death : MonoBehaviour {
	// Use this for initialization
	private Rigidbody2D rb2d;
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	///Player dies if they fall off the map
	void Update () {
		Vector3 playerPos = transform.position;
		if(playerPos.y < -2.5) {
			//rb2d.AddForce (Vector2.up * 100);
			kill();
			//Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnCollisionEnter2D(Collision2D col){

		if (col.gameObject.tag == "Enemy" && col.transform.position.y < transform.position.y-.25) {
			rb2d.AddForce ((Vector2.up * 3) * 60);
		}
	}

	///Kill the player
	void kill(){
		GameObject.FindGameObjectWithTag("Score").SendMessage("Death");
	}
}
