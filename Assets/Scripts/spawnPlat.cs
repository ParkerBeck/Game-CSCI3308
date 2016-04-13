using UnityEngine;
using System.Collections;

public class spawnPlat : MonoBehaviour {

	// Use this for initialization
	private GameObject newObj;
	private float pos;
	private float platCount;
	private float randNum;
	void Start () {
		newObj = (GameObject)Instantiate (Resources.Load("plat1"));
		newObj.transform.position = new Vector3 (transform.position.x-1, newObj.transform.position.y, newObj.transform.position.z);
		pos = newObj.transform.position.x;
		platCount = 1.0f; 
		//newObj.transform.position = new Vector3(newObj.transform.position.x + 10, newObj.transform.position.y, newObj.transform.position.z)
	}
	
	// Update is called once per frame
	void Update () {
		if (platCount < 5) {
			randNum = Random.Range (1, 5);
			newObj = (GameObject)Instantiate (Resources.Load("plat" + randNum));
			newObj.transform.position = new Vector3 (pos + 6, newObj.transform.position.y + Random.Range(0,2), newObj.transform.position.z);
			pos = newObj.transform.position.x;
			platCount = platCount + 1;
		}
	}

	void destroyedPlat(){
		platCount = platCount - 1;
	}
}
