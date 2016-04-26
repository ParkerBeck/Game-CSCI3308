using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour {

	// Use this for initialization
	private Text txt; 
	public int currentScore;
	private int hp;
	private int level;
	private Canvas gameover;

	void Start () {
		gameover = GameObject.FindGameObjectWithTag("Gameover").GetComponent<Canvas>();
		gameover.enabled = false;
		txt = GetComponent<Text>();
		currentScore = PlayerPrefs.GetInt ("Score");
		hp = PlayerPrefs.GetInt ("Health");
		if (hp == 0) {
			hp = 5;
		}
		level = PlayerPrefs.GetInt ("Level");
		if (level == 0) {
			level = 1;
		}
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Score : " + currentScore + "  ";
		txt.text = txt.text + "Health : " + hp + "  Level : " + level;
		PlayerPrefs.SetInt("SHOWSTARTSCORE",currentScore);
	}

	void upDateScore(int AddedScore){
		currentScore += AddedScore; 
	}

	void Death(){
		//SceneManager.LoadScene("StartMenu");
		PlayerPrefs.SetInt ("Score", currentScore);
		PlayerPrefs.SetInt ("Health", hp);
		PlayerPrefs.SetInt ("Level", level);
		Time.timeScale = 0;
		gameover.enabled = true;

	}
	void NextLevel(){
		PlayerPrefs.SetInt ("Score", currentScore+1000);
		PlayerPrefs.SetInt ("Health", hp + 3);
		PlayerPrefs.SetInt ("Level", level + 1);
		SceneManager.LoadScene("Level1");
	}
	void dmg(int dmg){
		hp = hp - dmg;
		if (hp <= 0) {
			Death ();
		}
	}
}
