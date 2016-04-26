using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	
	///Object will be destroyed if jumped on, otherwise player will take damage
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" && (col.gameObject.transform.position.y - transform.position.y) > 0.25) {
			Destroy (gameObject, 0.02f);
			GameObject.Find ("Score").SendMessage ("upDateScore", 100);
		} else if (col.gameObject.tag == "Player") {
			GameObject.Find ("Score").SendMessage ("dmg", 1);
		}
	}
	
	///Player takes damage if contact is maintained 
	void OnCollisionStay2d(Collision2D col){
		if (col.gameObject.tag == "Player") {
			GameObject.Find ("Score").SendMessage ("dmg", 1);
		}
	}
}
