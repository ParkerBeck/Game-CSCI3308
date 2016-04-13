using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour {
	
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" && (col.gameObject.transform.position.y-transform.position.y) > 0.25) {
			Destroy (gameObject,0.02f);
			GameObject.Find ("Score").SendMessage ("upDateScore", 100);
		}
	}
}
