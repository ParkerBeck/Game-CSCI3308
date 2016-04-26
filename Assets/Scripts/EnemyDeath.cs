using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Player")
		{
			//if(other.getXComponent() > gameObject.getXComponent && other.getYComponent == gameObject.getYComponent){
          
           // other.gameObject.SetActive(false);
          //}
        }

        if (other.tag == "BackScene")
        {
            other.gameObject.SetActive(true);
        }
        
        

        //Get Y axis, Check if player y is greater than enemy y
        //Set game object to null
        //Load new game object into scene.
    }
}
