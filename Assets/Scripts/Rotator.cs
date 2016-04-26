using UnityEngine;
using System.Collections;


///Currently unused
public class Rotator : MonoBehaviour {

    public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector2(0, 15) * Time.deltaTime * speed);
	}
}
