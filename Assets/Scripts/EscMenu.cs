using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EscMenu : MonoBehaviour {

	public Canvas escMenu;
	public Button MM;
	public Button DT;
	public Button Close;
	bool isPaused;

	// Use this for initialization
	void Start () {
		escMenu = escMenu.GetComponent<Canvas> ();
		MM = MM.GetComponent<Button> ();
		DT = DT.GetComponent<Button> ();
		Close = Close.GetComponent<Button> ();
		escMenu.enabled = false;
		isPaused = false;
	}

	public void QDTPress (){

		Application.Quit ();

	}

	public void QMMPress (){


		SceneManager.LoadScene ("StartMenu");

	}

	public void ClosePress() {

		escPress ();

	}


	public void escPress (){
		isPaused = !isPaused;
		if (isPaused == true) {
			//things
			Time.timeScale = 0.0F;
			escMenu.enabled = true;

		}

		if (isPaused == false) {
			//other things
			Time.timeScale = 1.0F;
			escMenu.enabled = false;
		}
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
			escPress();
	}
}
