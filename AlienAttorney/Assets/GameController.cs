using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public ButtonPress button;
	public Light opt1, opt2, opt3;




	// Use this for initialization
	void Start () {
		//button = GetComponent<ButtonPress>();

	
	}
	
	// Update is called once per frame
	void Update () {

		if (button.isPressed && opt1.enabled){

			Debug.Log ("option 1 selected!");
			opt1.color = Color.red;

		}

		if (button.isPressed && opt2.enabled){
			
			Debug.Log ("option 2 selected!");
			opt2.color = Color.blue;
			
		}

		if (button.isPressed && opt3.enabled){
			
			Debug.Log ("option 3 selected!");
			opt3.color = Color.green;
			
		}
	}
}
