using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrosController : MonoBehaviour {	
	public GameObject[] Cars;
	public float MaxPos, MinPos;
	[Range(0,1)]
	public float NoChance;
	public void GenerateCars(Transform city){
		if(Random.value < NoChance) return;
		int p = Random.Range(0, Cars.Length);
		GameObject newPlaca = Instantiate(Cars[p]);
				newPlaca.transform.parent = city;
				newPlaca.transform.localScale = Cars[p].transform.localScale;
				Vector3 pos = Cars[p].transform.position;
				newPlaca.transform.localPosition = new Vector3(Random.Range(MinPos, MaxPos), pos.y, pos.z); 
				newPlaca.transform.localRotation = Cars[p].transform.rotation;
	}
}
