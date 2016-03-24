using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelCompletion : MonoBehaviour {

    public string LevelName;
    public GUIText endLevelText;
    bool endLevel;

    void Update ()
    {
        if(endLevel && Input.GetKeyDown(KeyCode.Return))
        {
            SceneManager.LoadScene(LevelName);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            endLevelText.gameObject.SetActive(true);
            endLevel = true;
        }
    }
}
