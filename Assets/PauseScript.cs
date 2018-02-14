using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour {
	bool Paused = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Pause(){
		Paused = !Paused;
		Time.timeScale = Paused ? 0 : 1;
	}
}
