using UnityEngine;
using System.Collections;

public class CharacterMover : MonoBehaviour {

	public bool interact = false;
	public bool grounded = false;
	public Transform lineStart, lineEnd, groundedEnd;

	public GameObject kissShot;

	public float jumpForce = 500f;

	public float speed = 6f;

	float jumpTime, jumpDelay = .5f;
	float kissTime, kissDelay = .5f;
	bool jumped;

	bool kissed;

	RaycastHit2D whatIHit;

	public GameObject clone;

	Animator anim;

	//public Vector3 reformedEnemy;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Movement ();
		Raycasting ();

		if (Input.GetKeyDown (KeyCode.Space)) {
			anim.SetTrigger ("kiss");
			//anim.SetTrigger ("stopkiss");
			//kissTime = kissDelay;
			//kissed = true;
			Instantiate(kissShot, lineEnd.position, Quaternion.identity);

			
		}
		//kissTime +=
		if (Input.GetKeyUp (KeyCode.Space)) {
			anim.SetTrigger ("stopkiss");
			//kissed = false;
		}
	}

	void Raycasting()
	{
		Debug.DrawLine (lineStart.position, lineEnd.position, Color.magenta);
		Debug.DrawLine (this.transform.position, groundedEnd.position, Color.magenta);

		grounded = Physics2D.Linecast(this.transform.position, groundedEnd.position, 1 << LayerMask.NameToLayer ("ground"));

		if (Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Enemy"))) {
			whatIHit = Physics2D.Linecast (lineStart.position, lineEnd.position, 1 << LayerMask.NameToLayer ("Enemy"));
			interact = true;
		} else {
			interact = false;
		}
		if (Input.GetKeyDown (KeyCode.Space) && interact == true) {
			Destroy (whatIHit.collider.gameObject);

			//anim.SetTrigger ("kiss");
			//Instantiate (clone, new Vector3(reformedEnemy), Random.rotation);
		}



		//Physics2D.IgnoreLayerCollision (11, 12);

	}
	void Movement()
	{
		anim.SetFloat("speed", Mathf.Abs(Input.GetAxis ("Horizontal")));

		if (Input.GetAxisRaw ("Horizontal") > 0) 
		{
			transform.Translate(Vector2.right * speed *Time.deltaTime);
			transform.eulerAngles = new Vector2(0,0);
		}
		if (Input.GetAxisRaw ("Horizontal") < 0)
		{
			transform.Translate(Vector2.right * speed *Time.deltaTime);
			transform.eulerAngles = new Vector2(0,180);
		}
		if (Input.GetKeyDown (KeyCode.W) && grounded == true) {
			rigidbody2D.AddForce (Vector2.up * jumpForce);
			jumpTime = jumpDelay;
			anim.SetTrigger("jump");
			jumped = true;
		}

		jumpTime -= Time.deltaTime;

		if (jumpTime <= 0 && grounded && jumped) {
			anim.SetTrigger ("land");
			jumped = false;
		}
	}
}
