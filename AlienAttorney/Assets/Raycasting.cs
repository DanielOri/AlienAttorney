using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	public RaycastHit hit;
	Ray ray;
	public bool onObj = false;
	public GameObject light;

	GameObject lastHit;

	// Update is called once per frame
	void Update () {	

		if (Physics.SphereCast(transform.position, 2f, transform.forward*1000, out hit)){
			if (hit.collider.gameObject != lastHit){
				if(lastHit==null) lastHit = hit.collider.gameObject;
				lastHit.GetComponent<Light>().enabled = false;
				lastHit = hit.collider.gameObject;
				lastHit.GetComponent<Light>().enabled = true;
			} else {
				lastHit = hit.collider.gameObject;
				lastHit.GetComponent<Light>().enabled = true;
			}
		}
		else{
			if(lastHit!=null) lastHit.GetComponent<Light>().enabled = false;
		}


	}


}
