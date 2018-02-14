using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	public static bool AudioActive = true;
	
	// Use this for initialization
	void Start () {
		Camera.main.GetComponent<AudioListener>().enabled = AudioActive;
	}

	public void ChangeAudio()
	{
		AudioActive = !AudioActive;
		Camera.main.GetComponent<AudioListener>().enabled = AudioActive;
	}	
	// Update is called once per frame
	void Update () {
		
	}
}
