using UnityEngine;
using System.Collections;

public class moveAndDestroy : MonoBehaviour {

	public float kissSpeed = 300f;
	GameObject player;




	// Use this for initialization
	void Start () {

		player = GameObject.FindGameObjectWithTag ("Player");
		if (player.transform.rotation.y == 0) {
			rigidbody2D.AddForce (new Vector2 (kissSpeed, 0));
		} else if (player.transform.rotation.y !=0) {
			rigidbody2D.AddForce (new Vector2 (-kissSpeed, 0));
		}
	
	}
	
	// Update is called once per frame
	void Update () {
		Destroy (this.gameObject, 2.0f);

	}
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("enemy")) {
			Destroy(other.gameObject);
		}

	}
}
