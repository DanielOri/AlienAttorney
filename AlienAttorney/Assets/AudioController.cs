using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour {

	AudioSource source;
	public AudioClip[] effectSounds;
	public AudioClip[] alienSounds;

	// Use this for initialization
	void Start () {

		source = GetComponent<AudioSource>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void playHandRecognizer(){
		source.audio.clip = effectSounds[0];
		audio.Play();
	}

	void playAlienSummon(){
		audio.clip = effectSounds[0];
		audio.Play();


	}



}
