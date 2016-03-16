using UnityEngine;
using System.Collections;

//this basic enemy will move through terrain (will usually be placed in the air so it doesn't look weird)
//it will go in a sine curve patter either up or down from its placement depending on a random number it generates
//place these over gaps the player has to jump over like the medusas from castlevania, or just put them there for flavor
//can kill these once they go offscreen via death.cs
//right now it has no interaction with the player. Have to decide: Are they killable? How so? 
//this one actually uses my movement script so it extends MobileObject
public class BasicEnemyController : MonoBehaviour {

	// Use this for initialization
	private Rigidbody2D rb2d;
	Animator BasicEnemyAnim;
	//the 
	private int UpDown;
	private int MoveCount;
	private bool forceCheck;
	protected void Start () {
		UpDown = Random.Range (0, 1); //0 is down, 1 is up
		forceCheck = false;
		rb2d = GetComponent<Rigidbody2D> ();
		MoveCount = 0; //when it gets to SOME NUMBER, reverses movement direction, and so on

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit2D hit;
		//print (MoveCount);
		float udforce = 70f;
		float lforce = 120f;
		print (MoveCount);
		if (UpDown == 0) 
		{
			if (MoveCount < 120) {
				if (forceCheck == false) 
				{
					rb2d.AddForce ((Vector2.down) * udforce);
					rb2d.AddForce ((Vector2.left) * lforce);
					forceCheck = true;
				}
				MoveCount += 1;
			} 
			else 
			{
				rb2d.AddForce ((Vector2.up) * 2f * udforce);
				MoveCount = 0;
				UpDown = 1;
				forceCheck = false;
			}

		} 
		else 
		{
			if (MoveCount < 120) {
				if (forceCheck == false) 
				{
					rb2d.AddForce ((Vector2.up) * udforce);
					rb2d.AddForce ((Vector2.left) * lforce);
					forceCheck = true;
				}
				MoveCount += 1;
			} 
			else 
			{
				rb2d.AddForce ((Vector2.down) * 2f * udforce);
				MoveCount = 0;
				UpDown = 0;
				forceCheck = false;
			}
				
		}



	}
}
