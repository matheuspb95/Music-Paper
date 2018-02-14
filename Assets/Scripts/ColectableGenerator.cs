using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectableGenerator : MonoBehaviour {
	public float LimitX;
	public GameObject ColectablePrefab;
	public Transform Aviao;
	public float Time;
	// Use this for initialization
	void Start () {
		StartCoroutine(Generate());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Generate(){
		while(true){
			yield return new WaitForSeconds(Time);
			GameObject newColectable = Instantiate(ColectablePrefab);
			newColectable.transform.position = new Vector3(Random.Range(-LimitX, LimitX), Aviao.position.y, 50);
		}
	}
}
