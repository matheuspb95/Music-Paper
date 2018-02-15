using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
	public AudioSource Music01, Music02;
	public Transform player;
	public float volume;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		//if(player.position.y < 0){
			volume = (player.position.y + 5) / 10;
			Music01.volume = volume;
			Music02.volume = 1 - volume;
		//}
	}
}
