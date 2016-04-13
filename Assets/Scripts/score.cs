using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class score : MonoBehaviour {

	// Use this for initialization
	private Text txt; 
	public int currentScore;

	void Start () {
		txt = GetComponent<Text>();
		currentScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
		txt.text = "Score : " + currentScore;
		PlayerPrefs.SetInt("SHOWSTARTSCORE",currentScore);
	}

	void upDateScore(int AddedScore){
		currentScore += AddedScore; 
	}
}
