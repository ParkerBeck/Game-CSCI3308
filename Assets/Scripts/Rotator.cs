using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

    public float speed;
    public int yRotate;
    public int xRotate;
    public int yMove;
    public int xMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector2(xRotate, yRotate) * Time.deltaTime * speed);
        transform.Translate(new Vector2(xMove, yMove) * Time.deltaTime * speed);
	}
}
