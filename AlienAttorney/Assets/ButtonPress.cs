using UnityEngine;
using System.Collections;

public class ButtonPress : MonoBehaviour {

	public bool isPressed = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


	
	}


	void OnTriggerEnter(Collider hand){
		
		if (!isPressed){
			isPressed = true;
			transform.position = new Vector3 (transform.position.x, transform.position.y - .4f, transform.position.z);
		}
		

	}

	void OnTriggerExit(Collider hand){

		isPressed = false;
		transform.position = new Vector3 (transform.position.x, transform.position.y + .4f, transform.position.z);

	}

}
