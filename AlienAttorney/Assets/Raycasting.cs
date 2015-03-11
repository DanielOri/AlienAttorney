using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	public RaycastHit hit;
	Ray ray;
	public bool onObj = false;
	public GameObject light;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {	
		ray = new Ray( transform.position, transform.forward);//Camera.main.ScreenPointToRay(Input.mousePosition);

		Debug.DrawRay(ray.origin, ray.direction, Color.green);

		if (Physics.Raycast(ray, out hit)){

			Debug.Log ("hit");

			if (hit.collider.tag == "Cube"){
				Debug.Log("hit cube");
				onObj = true;
				//hit.collider.gameObject.GetComponent<Light>().enabled =true;
				
				
			} else {
				onObj = false;
				//hit.collider.gameObject.GetComponent<Light>().enabled =false;

			}


		}

		if (onObj){
			GameObject.Find("Light").GetComponent<Light>().enabled = true;


		} else {
			GameObject.Find("Light").GetComponent<Light>().enabled = false;
		}



	}


}
