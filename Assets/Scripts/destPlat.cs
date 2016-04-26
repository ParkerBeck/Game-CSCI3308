using UnityEngine;
using System.Collections;

public class destPlat : MonoBehaviour {

	// Use this for initialization
	private GameObject camPos;
	void Start () {
		camPos = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	///Destroys platforms that are off screen
	void Update () {
		if ((camPos.transform.position.x - transform.position.x) > 10) {
			camPos.SendMessage ("destroyedPlat");
			Destroy (gameObject);
		}
	}
}
