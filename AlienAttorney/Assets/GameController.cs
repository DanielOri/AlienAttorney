using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject alien, hair;
	public ButtonPress button;

	public GameObject leftImage, rightImage, topImage;
	public Light opt1, opt2, opt3;

	public bool gameStart = false;
	float upSpeed = 0.1f;

	public bool alienTalks = false;
	int alienTalkID = 0;

	string imageID = "NONE";

	string gameStatus = "standBy";

	AudioController ac;


	// Use this for initialization
	void Start () {

		ac = GameObject.Find("Audio Manager").GetComponent<AudioController>();

	
	}
	
	// Update is called once per frame
	void Update () {

		firstInteraction();

		makeAlienMove();

		makeAlienTalk(alienTalkID);

		pushButtonAction(gameStatus);

		moveImages(imageID, 0.05f);

		chooseOption();

		moveHair(gameStatus, .04f);

		moveAlienAndHair(gameStatus, .04f);

	}

	void StartGame(){
		if (!gameStart){
			Debug.Log ("game started");
			gameStart = true;
			alienTalks = true;
			alienTalkID = 1;
			StartCoroutine("firstInteraction");
		}
	}



	void makeAlienMove(){
		if (gameStatus == "alienShowsUp"){
			Debug.Log ("moving alien");
			alien.transform.position = new Vector3( alien.transform.position.x,
													alien.transform.position.y + upSpeed,
													alien.transform.position.z
			                                       );
		}
	}

	void makeAlienTalk(int times){

		if (alienTalks == true && times == 1){

			//play first audio file play
			//repeat that until the player pushes the button
		}
		if (alienTalks == true && times == 2){
			//play first audio file play
			//repeat that until the player pushes the button
		}
		if (alienTalks == true && times == 3){
			//play first audio file play
			//repeat that until the player pushes the button
		}
		if (alienTalks == true && times == 4){
			//play first audio file play
			//repeat that until the player pushes the button
		}

	}

	void pushButtonAction(string status){

		if (status == "start" && button.isPressed){

			Debug.Log ("show pictures");
			gameStatus = "standBy";
			StartCoroutine("alienShowOptions");
			alienTalks = false;
			button.isPressed = false;


		}

	}

	void moveImages(string image, float speed){

		if (image == "LEFT" && leftImage.transform.position.x < -9f){
			leftImage.transform.position = new Vector3( leftImage.transform.position.x + speed,
			                                            leftImage.transform.position.y,
			                                            leftImage.transform.position.z
			                                           );
		} else if (image == "RIGHT" && rightImage.transform.position.x > 3.2f){
			rightImage.transform.position = new Vector3( rightImage.transform.position.x - speed,
			                                             rightImage.transform.position.y,
			                                             rightImage.transform.position.z
			                                            );
		} else if (image == "TOP" && topImage.transform.position.y > 10.5f){
			topImage.transform.position = new Vector3( topImage.transform.position.x,
			                                           topImage.transform.position.y - speed,
			                                           topImage.transform.position.z
			                                           );
		} else if (image == "ALL"){
			if (leftImage.transform.position.x > -12f){
				leftImage.transform.position = new Vector3( leftImage.transform.position.x - speed,
				                                           leftImage.transform.position.y,
				                                           leftImage.transform.position.z
				                                           );
			}
			if (rightImage.transform.position.x < 6.2f){
				rightImage.transform.position = new Vector3( rightImage.transform.position.x + speed,
				                                            rightImage.transform.position.y,
				                                            rightImage.transform.position.z
				                                            );
			}
			if (topImage.transform.position.y < 16.5f){
				topImage.transform.position = new Vector3( topImage.transform.position.x,
				                                          topImage.transform.position.y + speed,
				                                          topImage.transform.position.z
				                                          );
			}


		}


	}

	void chooseOption(){

		if(gameStatus == "makeChoice"){
			if (button.isPressed && opt1.enabled){
				
				Debug.Log ("option 1 selected!");
				opt1.color = Color.red;
				gameStatus = "standBy";
				StartCoroutine("endGame");
				button.isPressed = false;
				
			}
			
			if (button.isPressed && opt2.enabled){
				
				Debug.Log ("option 2 selected!");
				opt2.color = Color.blue;
				gameStatus = "standBy";
				StartCoroutine("endGame");
				button.isPressed = false;
				
			}
			
			if (button.isPressed && opt3.enabled){
				
				Debug.Log ("option 3 selected!");
				opt3.color = Color.green;
				gameStatus = "standBy";
				StartCoroutine("endGame");
				button.isPressed = false;
				
			}
		}


	}

	void moveHair(string state, float speed){

		if (state == "moveHair" && hair.transform.position.y > 10f){

			hair.transform.position = new Vector3( hair.transform.position.x,
			                                       hair.transform.position.y - speed,
			                                       hair.transform.position.z
			                                          );

		}

	}

	void moveAlienAndHair(string state, float speed){
		
		if (state == "alienIsOut"){
			
			hair.transform.position = new Vector3( hair.transform.position.x,
			                                      hair.transform.position.y - speed,
			                                      hair.transform.position.z
			                                      );

			alien.transform.position = new Vector3( alien.transform.position.x,
			                                      alien.transform.position.y - speed,
			                                      alien.transform.position.z
			                                      );
			
		}
		
	}

	IEnumerator firstInteraction(){
		ac.playHandRecognizer();
		yield return new WaitForSeconds(2.15f);
		gameStatus = "alienShowsUp";
		yield return new WaitForSeconds(2.19f);
		Debug.Log ("end of corountine");
		upSpeed = 0f;
		gameStatus = "start";

	}

	IEnumerator alienShowOptions(){
		imageID = "LEFT";

		yield return new WaitForSeconds(3f);
		imageID = "RIGHT";
		yield return new WaitForSeconds(3f);
		imageID = "TOP";
		yield return new WaitForSeconds(3f);
		imageID = "NONE";
		gameStatus = "makeChoice";

	}

	IEnumerator endGame(){
		imageID = "ALL";
		yield return new WaitForSeconds(5f);
		imageID = "NONE";
		Debug.Log ("show hair");
		gameStatus = "moveHair";
		yield return new WaitForSeconds(4f);
		gameStatus = "standBy";
		Debug.Log("alien ends the game");
		yield return new WaitForSeconds(5f);
		gameStatus = "alienIsOut";
		yield return new WaitForSeconds(5f);
		gameStatus = "end";
		Debug.Log("game over");
	}


}
