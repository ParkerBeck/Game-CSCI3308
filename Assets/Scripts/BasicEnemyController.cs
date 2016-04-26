using UnityEngine;
using System.Collections;

//this basic enemy will move through terrain (will usually be placed in the air so it doesn't look weird)
//it will go in a sine curve patter either up or down from its placement depending on a random number it generates
//place these over gaps the player has to jump over like the medusas from castlevania, or just put them there for flavor
//can kill these once they go offscreen via death.cs
//right now it has no interaction with the player. Have to decide: Are they killable? How so? 
//this one actually uses my movement script so it extends MobileObject
public class BasicEnemyController : MobileObject {

	// Use this for initialization
	private Rigidbody2D rb2d;
	Animator BasicEnemyAnim;
	///Direction enemy should move
	private int UpDown;
	private int MoveCount;
	void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D>();
		BasicEnemyAnim = GetComponent<Animator>();
		UpDown = Random.Range (0, 1); //0 is down, 1 is up
		MoveCount = 0; //when it gets to 180, reverses movement direction, and so on
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit;
		if (UpDown == 0) 
		{
			if (MoveCount < 180) 
			{
				base.Move (0, -1, out hit); //Haven't tested this to figure out what's the best Ydir for moving per frame yet
				MoveCount += 1;
			}
			else
			{
				MoveCount = 0;
				UpDown = 1; //reverses direction for that up and down motion
			}
		} 
		else 
		{
			if (MoveCount < 180) 
			{
				base.Move (0, 1, out hit); //Haven't tested this to figure out what's the best Ydir for moving per frame yet
				MoveCount += 1;
			}
			else
			{
				MoveCount = 0;
				UpDown = 0; //reverses direction for that up and down motion
			}
		}



	}
}
