using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCutScene : MonoBehaviour {
	public ChangeScene changer;
	// Use this for initialization
	void Start () {
		StartCoroutine(Wait());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Wait(){
		yield return new WaitForSeconds(10);
		changer.LoadScene("Main");
	}
}
