using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacasController : MonoBehaviour {
	public GameObject[] LeftPieces;
	public GameObject[] RightPieces;

	public float CitySize;
	public int Pieces;
	float dist;
	public float MinLeftPos = 0.09f, MaxLeftPos = 0.11f, MinRightPos = 0.17f, MaxRightPos = 0.19f;
	public float MaxY = 0.1f, MinY = 0.05f;
	// Use this for initialization
	void Start () {
		dist = 0.0165f;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Generate(Transform citypiece){
		for(int i = 0; i < Pieces; i++){
			if(Random.value < 0.5f){
				int p = Random.Range(0, LeftPieces.Length);
				GameObject newPlaca = Instantiate(LeftPieces[p]);
				newPlaca.transform.parent = citypiece;
				newPlaca.transform.localScale = LeftPieces[p].transform.localScale;
				newPlaca.transform.localPosition = new Vector3(Random.Range(MinLeftPos, MaxLeftPos),
														dist * i - 0.022f, 
														Random.Range(MinY, MaxY));
				newPlaca.transform.localRotation = LeftPieces[p].transform.rotation;
			}else{
				int p = Random.Range(0, RightPieces.Length);
				GameObject newPlaca = Instantiate(RightPieces[p]);
				newPlaca.transform.parent = citypiece;
				newPlaca.transform.localScale = RightPieces[p].transform.localScale;
				newPlaca.transform.localPosition = new Vector3(Random.Range(MinRightPos, MaxRightPos),
														dist * i - 0.022f,
														Random.Range(MinY, MaxY));
				newPlaca.transform.localRotation = RightPieces[p].transform.rotation;
			}
		}
	}
}
