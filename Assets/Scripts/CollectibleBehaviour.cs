using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleBehaviour : MonoBehaviour {
	public PlaneMovement player;
	public float ForwardVelocity, ScaleTime;
	float FinalSize, t;
	Rigidbody body;
	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<PlaneMovement>();
		body = GetComponent<Rigidbody>();
		body.velocity = new Vector3(0, -player.DownVelocity, ForwardVelocity);
		FinalSize = transform.localScale.x;
		transform.localScale = Vector3.zero;
		t = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if(t < 1){
			t += Time.deltaTime / ScaleTime;
			transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one * FinalSize, t);
		}
		if(transform.position.z < 0) Destroy(this.gameObject);
		//transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
	}
}
