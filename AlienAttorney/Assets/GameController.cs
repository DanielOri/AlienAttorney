using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject alien;
	public ButtonPress button;
	public Light opt1, opt2, opt3;

	public bool gameStart = false;
	float upSpeed = 0.4f;

	public bool alienTalks = false;
	int alienTalkID = 0;

	string gameStatus = "standBy";


	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {

		firstInteraction();

		makeAlienMove();

		//chooseOption();

		makeAlienTalk(alienTalkID);

		pushButtonAction(gameStatus);

	}

	void StartGame(){
		if (!gameStart){
			Debug.Log ("game started");
			gameStart = true;
			StartCoroutine("firstInteraction");
		}
	}



	void makeAlienMove(){
		if (gameStart){
			Debug.Log ("moving alien");
			alien.transform.position = new Vector3(alien.transform.position.x, alien.transform.position.y + upSpeed, alien.transform.position.z);
		}
	}

	void makeAlienTalk(int times){

		if (alienTalks == true && times == 1){
			//play first audio file play
			//repeat that until the player pushes the button
		}

	}

	void pushButtonAction(string status){

		if (status == "start" && button.isPressed){

			Debug.Log ("show pictures");
			gameStatus = "standBy";
			StartCoroutine("alienShowOptions");


		}

	}

	void chooseOption(){
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

	IEnumerator firstInteraction(){	
		yield return new WaitForSeconds(1f);
		Debug.Log ("end of corountine");
		upSpeed = 0f;
		alienTalks = true;
		alienTalkID = 1;
		gameStatus = "start";

	}

	IEnumerator alienShowOptions(){

		yield return new WaitForSeconds(0f);

	}


}
