using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class death : MonoBehaviour {
	//private Rigidbody2D rb2d;
	// Use this for initialization
	private Scene scene;
	void Start () {
		scene = SceneManager.GetActiveScene();
		//rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = transform.position;
		if(playerPos.y < -2.5) {
			//rb2d.AddForce (Vector2.up * 100);

			SceneManager.LoadScene(scene.name);
			//Application.LoadLevel(Application.loadedLevel);
		}
	}
}
