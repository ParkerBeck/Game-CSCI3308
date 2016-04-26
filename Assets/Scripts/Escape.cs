using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	///Exits to menu on key press "Escape"
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("StartMenu");
	}
}
