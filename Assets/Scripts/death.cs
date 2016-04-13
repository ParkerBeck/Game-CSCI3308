using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class death : MonoBehaviour {
	// Use this for initialization
	private Scene scene;
	private Rigidbody2D rb2d;
	void Start () {
		scene = SceneManager.GetActiveScene();
		rb2d = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = transform.position;
		if(playerPos.y < -2.5) {
			//rb2d.AddForce (Vector2.up * 100);
			Destroy(gameObject,1.0f);
			SceneManager.LoadScene("StartMenu");
			//Application.LoadLevel(Application.loadedLevel);
		}
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Enemy" && (transform.position.y - col.gameObject.transform.position.y) < 0.25) {
			//Destroy (gameObject, 1.0f);
			//SceneManager.LoadScene("StartMenu");
		}

		if (col.gameObject.tag == "Enemy") {
			rb2d.AddForce ((Vector2.up * 3) * 60);
		}
	}
}
