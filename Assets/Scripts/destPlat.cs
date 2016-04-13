using UnityEngine;
using System.Collections;

public class destPlat : MonoBehaviour {

	// Use this for initialization
	private GameObject camPos;
	void Start () {
		camPos = GameObject.FindGameObjectWithTag("MainCamera");
	}
	
	// Update is called once per frame
	void Update () {
		if ((camPos.transform.position.x - transform.position.x) > 10) {
			camPos.SendMessage ("destroyedPlat");
			Destroy (gameObject);
		}
	}
}
