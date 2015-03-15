using UnityEngine;
using System.Collections;

public class TrackTheHand : MonoBehaviour {



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (GameObject.Find("MinimalHand(Clone)")){

			//transform.position = GameObject.Find("MinimalHand(Clone)").GetComponent<Transform>().transform.InverseTransformPoint(GameObject.Find("MinimalHand(Clone)").GetComponent<Transform>().transform.position);
		} else{
			return;

		}
	}
}
