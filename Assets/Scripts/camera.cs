using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {
	
	///Object the camera should follow
	private GameObject trackingObject;
	
	void Start () {
		trackingObject = GameObject.FindGameObjectWithTag ("Player");
	}
	
	///Moves the camera to follow the player.
	void Update () {
		float location = trackingObject.transform.position.x;
		if (location > transform.position.x) {
			this.transform.position = new Vector3 (location, this.transform.position.y, this.transform.position.z);

		}
	}
}
