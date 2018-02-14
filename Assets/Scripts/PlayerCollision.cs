using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour {
	PlayerCollectable collectable;
	PlaneMovement movement;
	public GameObject EndGameScreen;
	public MovingCity city;
	public Transform camera;
	bool cameraFollow;
	// Use this for initialization
	void Start () {
		cameraFollow = false;
		collectable = GetComponent<PlayerCollectable>();
		movement = GetComponent<PlaneMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(cameraFollow){
			Vector3 dir = transform.position - camera.position;
			camera.forward = dir;
			camera.position = new Vector3(transform.position.x, 5, transform.position.z);
		}
	}

	void OnTriggerEnter(Collider coll){
		if(coll.gameObject.CompareTag("Collectable")){
			collectable.Collect();
		} else if(coll.gameObject.CompareTag("Obstaculos")){
			if(collectable.immune) return;
			camera.parent = null;
			cameraFollow = true;
			movement.DownVelocity = 25;
		}		
	}

	void OnCollisionEnter(Collision coll){
		 if(coll.gameObject.CompareTag("Chao")){
			GameOver();
		}
	}

	public void GameOver(){
		city.CanCount = false;			
		city.Velocity = 0;
		EndGameScreen.SetActive(true);
		GetComponent<Rigidbody>().isKinematic = true;
	}
}
