using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class spawnPlat : MonoBehaviour {

	// Use this for initialization
	private GameObject newObj;
	private float pos;
	private float platCount;
	private float randNum;
	private float totPlat;
	private float levelAugment;
	void Start () {
		//newObj = (GameObject)Instantiate (Resources.Load("plat1"));
		//newObj.transform.position = new Vector3 (transform.position.x-1, newObj.transform.position.y, newObj.transform.position.z);
		//pos = newObj.transform.position.x + 4;
		newObj = (GameObject)Instantiate (Resources.Load("Lrg"));
		newObj.transform.position = new Vector3 (transform.position.x-1, newObj.transform.position.y, newObj.transform.position.z);
		pos = newObj.transform.position.x + 3;
		//newObj.tag = "Ter";
		platCount = 1.0f; 
		totPlat = 1.0f;
		levelAugment = PlayerPrefs.GetInt ("Level")*2 + 30;
		//newObj.transform.position = new Vector3(newObj.transform.position.x + 10, newObj.transform.position.y, newObj.transform.position.z)
	}
	
	// Update is called once per frame
	void Update () {
		if (platCount < 20 && totPlat < levelAugment) {
			randNum = Random.Range (1, 4);
			if (randNum == 1) {
				newObj = (GameObject)Instantiate (Resources.Load("Sml"));
				newObj.transform.position = new Vector3 (pos, newObj.transform.position.y + Random.Range(0,2), newObj.transform.position.z);
				pos = newObj.transform.position.x + 1;
			}
			if (randNum == 2) {
				newObj = (GameObject)Instantiate (Resources.Load("Med"));
				newObj.transform.position = new Vector3 (pos, newObj.transform.position.y + Random.Range(0,2), newObj.transform.position.z);
				pos = newObj.transform.position.x + 2;
			}
			if (randNum == 3) {
				newObj = (GameObject)Instantiate (Resources.Load("Lrg"));
				randNum = Random.Range (0, 2);
				newObj.transform.position = new Vector3 (pos, newObj.transform.position.y + randNum, newObj.transform.position.z);

				newObj = (GameObject)Instantiate (Resources.Load("enemyWorm"));
				newObj.transform.position = new Vector3 (pos+1, newObj.transform.position.y + randNum, newObj.transform.position.z);
				pos = newObj.transform.position.x + 3;
			}
			newObj.tag = "Ter";
			//newObj = (GameObject)Instantiate (Resources.Load("plat" + randNum));
			//newObj.transform.position = new Vector3 (pos + 6, newObj.transform.position.y + Random.Range(0,2), newObj.transform.position.z);
			platCount = platCount + 1;
			totPlat = totPlat + 1;
		}
		if (totPlat == levelAugment) {
			newObj = (GameObject)Instantiate (Resources.Load("End"));
			newObj.transform.position = new Vector3 (pos+2, newObj.transform.position.y, newObj.transform.position.z);
			pos = newObj.transform.position.x;
			totPlat = totPlat + 1;
		}
	}

	void destroyedPlat(){
		platCount = platCount - 1;
	}
}
