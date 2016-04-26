using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {
	public Canvas quitMenu;
	public Button startText;
	public Button quitText;

	// Use this for initialization
	void Start () {
		quitMenu = quitMenu.GetComponent<Canvas> ();
		startText = startText.GetComponent<Button> ();
		quitText = quitText.GetComponent<Button> ();
		quitMenu.enabled = false;
		Time.timeScale = 1;
	}

	public void QuitPress(){

		quitMenu.enabled = true;
		startText.enabled = false;
		quitText.enabled = false;

	}

	public void NoPress(){

		quitMenu.enabled = false;
		startText.enabled = true;
		quitText.enabled = true;

	}

	public void StartGame(){
		PlayerPrefs.DeleteAll ();
		SceneManager.LoadScene ("Level1");

	}


	public void Quit(){

		Application.Quit ();
	}
	
	// Update is called once per frame
	void Update () {

	}
		
}
