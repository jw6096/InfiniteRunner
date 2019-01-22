using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDeathTrigger : MonoBehaviour
{
	public BoxCollider2D leftCollider;
	public BoxCollider2D rightCollider;
	public BoxCollider2D topCollider;
	public BoxCollider2D bottomCollider;

    // Start is called before the first frame update
    void Start()
    {
		leftCollider.offset = new Vector2 ((-1) * Screen.width / 100, 0);
		leftCollider.size = new Vector2 (1, Screen.height / 50);

		rightCollider.offset = new Vector2 (Screen.width / 100, 0);
		rightCollider.size = new Vector2 (1, Screen.height / 50);

		topCollider.offset = new Vector2 (0, (-1) * Screen.height / 100);
		topCollider.size = new Vector2 (Screen.width / 50, 1);

		bottomCollider.offset = new Vector2 (0, Screen.height / 100);
		bottomCollider.size = new Vector2 (Screen.width / 50, 1);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnTriggerEnter2D(Collider2D other) 
	{
		//Debug.Log ("Collision: ");
		//Debug.Log (other);
		//Debug.Log (other.gameObject.GetComponent<SpriteRenderer> ().color);

		//other.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;

		Debug.Log ("Death Collision");
		other.gameObject.GetComponent<SpriteRenderer> ().color = Color.red;
	}
}
