using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour {
	PlaneMovement player;
	public float UpForce, duration;
	float StartForce;
	float t;

	public float Saturation;
	public CameraEffect cameraEffect;

	public MovingCity city;
	public AudioSource Ring;
	public Animator animator;
	public bool immune;

	// Use this for initialization
	void Start () {
		immune = false;
		t = 0;
		player = GetComponent<PlaneMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if(Saturation > -1){
			Saturation -= Time.deltaTime / 5;
		} else {
			Saturation = -1;
		}
		cameraEffect.intensity = Saturation;
		 */
	}

	public void Collect(){
		city.Distance += 10;
		Ring.Play();
		animator.Play("CircleAnim");
		//Saturation += 0.8f;
		StartCoroutine(Up());
	}

	IEnumerator Up(){
		
		immune = true;
		StartForce = player.DownVelocity;
		t = 0;
		while( t < 1){
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime;
			player.DownVelocity = Mathf.Lerp(UpForce + transform.position.y, StartForce, t);
		}
		immune = false;
	}
}
