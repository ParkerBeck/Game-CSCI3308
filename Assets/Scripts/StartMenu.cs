using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			LoadLevel1 ();
		if (Input.GetKeyDown (KeyCode.Escape))
			Appquit ();
	}

	bool LoadLevel1 () {
		SceneManager.LoadScene ("Level1");
		return true;
	}

	bool Appquit () {
		Application.Quit ();
	}
}
