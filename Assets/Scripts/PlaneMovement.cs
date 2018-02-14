using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMovement : MonoBehaviour {
	Rigidbody body;
	Vector3 StartAccel;
	public float MoveVelocity, MoveRotation, DownVelocity;
	public Transform Model;
	Camera main;
	public MovingCity city;


	// Use this for initialization
	void Start () {
		main = Camera.main;
		body = GetComponent<Rigidbody>();
		StartAccel = Input.acceleration;
	}

	float StartTouch;

	public float MaxLimitX, MinLimitX;
	
	// Update is called once per frame
	void Update () {
		if(!city.CanCount)
			return;
			
		float diff = 0;
		if(Input.GetMouseButtonDown(0)){
			StartTouch = main.ScreenToViewportPoint(Input.mousePosition).x;
		}

		if(Input.GetMouseButton(0)){
			diff = main.ScreenToViewportPoint(Input.mousePosition).x - StartTouch;
		}
			
		MoveObj(((Input.acceleration.x - StartAccel.x) * 1.5f) + (diff * 2));

		if(transform.position.x > MaxLimitX) {
			transform.position = new Vector3(MaxLimitX, transform.position.y, transform.position.z);
		}else if(transform.position.x < MinLimitX) {
			transform.position = new Vector3(MinLimitX, transform.position.y, transform.position.z);
		}
	}

	void MoveObj(float x){
		body.velocity = new Vector3(x  * MoveVelocity, -DownVelocity, 0);
		Quaternion targetRotation = Quaternion.Euler(-x * MoveRotation, -90, Mathf.Abs(DownVelocity * 2));
		Model.rotation = Quaternion.Lerp(Model.rotation, targetRotation, 0.5f);
	}
}
