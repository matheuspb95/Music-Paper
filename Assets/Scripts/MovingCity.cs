using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingCity : MonoBehaviour {
	public Rigidbody[] pieces;
	
	public Vector3 StartPoint;
	public float EndPoint;
	public float Velocity;
	public float Distance;
	public Text score;
	public bool CanCount; 
	PlacasController placas;
	// Use this for initialization
	void Start () {
		placas = GetComponent<PlacasController>();
		CanCount = true;
		//for(int i = 0; i < pieces.Length; i++){
		//	pieces[i].velocity = -Vector3.forward * Velocity;
		//}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(CanCount){
			Distance += Time.deltaTime;
			score.text = Mathf.CeilToInt(Distance).ToString("000000");
		}
		for(int i = 0; i < pieces.Length; i++){			
			pieces[i].position -= Vector3.forward * Velocity * Time.fixedDeltaTime;
			if(pieces[i].position.z < EndPoint){
				ResetPiece(i);
			}
		}
	}

	void ResetPiece(int i){
		if(i == pieces.Length-1) Velocity++;
		foreach (Transform child in pieces[i].transform) {
			GameObject.Destroy(child.gameObject);
		}
		pieces[i].position = StartPoint;
		placas.Generate(pieces[i].transform);
	}

	public int GetScore(){
		return Mathf.CeilToInt(Distance);
	}
}
