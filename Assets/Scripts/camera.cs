using UnityEngine;
using System.Collections;

public class camera : MonoBehaviour {

	// Use this for initialization
	private GameObject player;
	private float playerLoc;
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		playerLoc = player.transform.position.x;
		if (playerLoc > transform.position.x) {
			this.transform.position = new Vector3 (playerLoc, this.transform.position.y, this.transform.position.z);
			//bg.transform.position = new Vector3 (playerLoc, bg.transform.position.y, bg.transform.position.z);

		}
	}
}
