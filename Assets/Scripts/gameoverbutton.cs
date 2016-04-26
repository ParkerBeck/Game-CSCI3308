using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameoverbutton : MonoBehaviour {

	// Use this for initialization
	public Button MM;
	void Start () {
		//MM = MM.GetComponent<Button>();
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return))
			QMMPress ();
	}
	public void QMMPress(){
		SceneManager.LoadScene("StartMenu");
	}
}
