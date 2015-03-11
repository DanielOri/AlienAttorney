using UnityEngine;
using System.Collections;
using Leap;

public class RandomGesture : MonoBehaviour {

	public GameObject light1, light2;

	Leap.Controller controller;

	// Use this for initialization
	void Start () {
	
		controller = new Controller();
		controller.EnableGesture(Gesture.GestureType.TYPECIRCLE, true);

	}
	
	// Update is called once per frame
	void Update () {




		Frame frame = controller.Frame();
		foreach (Gesture gesture in frame.Gestures())
		{
			switch(gesture.Type)
			{
			case(Gesture.GestureType.TYPECIRCLE):
			
				Debug.Log("Circle gesture recognized.");
				break;

				default:
				Debug.Log("Bad gesture type");
				break;

			}
		
			}
		}

	}

