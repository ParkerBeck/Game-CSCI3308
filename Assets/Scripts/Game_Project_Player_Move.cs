using UnityEngine;
using System.Collections;

//jake made this
public abstract class MobileObject : MonoBehaviour { 
	///Speed of movement
	public float movetime = 0.1f; //can change this
	///Layers the object should not be able to travel on
	public LayerMask blockingLayer; 
	
	private BoxCollider2D boxCollider;
	private Rigidbody2D rb2D; 
	private float inverseMoveTime;

	///Gets components from the game object for later calculations
	protected virtual void Start () 
	{
		boxCollider = GetComponent<BoxCollider2D> ();
		rb2D = GetComponent<Rigidbody2D> ();
		inverseMoveTime = 1f / movetime;
		
	}

	///Moves the object, raycasting if to make sure it can traverse
	protected bool Move (float xDir, float yDir, out RaycastHit2D hit)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2 (xDir, yDir);
		boxCollider.enabled = false;
		hit = Physics2D.Linecast (start, end, blockingLayer); //NOTE: use whatever layer the project has
		boxCollider.enabled = true;
		if (hit.transform == null) 
		{
			StartCoroutine (SmoothMovement (end));
			return true;
		}
		
		return false;
	}

	///Keeps the pixel movement non jerky
	protected IEnumerator SmoothMovement (Vector3 end)
	{
		
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;
		
		while (sqrRemainingDistance > float.Epsilon) 
		{
			Vector3 newPostion = Vector3.MoveTowards(rb2D.position, end, inverseMoveTime * Time.deltaTime);
			
			rb2D.MovePosition (newPostion);
			
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			
			yield return null;
		}
	}
}
		/*this is all that is TECHNICALLY NEEDED for movement to occur. to use these functions in a different class
		 * or in the same file, use the format boolean var = Move (xDir, yDir, zzz), where zzz is a Raycast2D.
		 * The boolean currently has no purpose, but will be useful in the future to determine if the object
		 * CANNOT move because there is something in the way, or other such cases. 
		 */
