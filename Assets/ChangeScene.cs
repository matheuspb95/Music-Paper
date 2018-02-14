using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour {
	public Image FadePanel;
	// Use this for initialization
	void Awake () {
		FadePanel.color = Color.black;
		StartCoroutine(Fade(Color.black, Color.clear));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void LoadScene(string scene){
		StartCoroutine(LoadSceneWithFade(scene));
	}

	IEnumerator Fade(Color start, Color end){
		float t = 0;
		while (t < 1){
			yield return new WaitForEndOfFrame();
			t += Time.deltaTime * 2;
			FadePanel.color = Color.Lerp(start, end, t);
		}
		FadePanel.color = end;
	}

	IEnumerator LoadSceneWithFade(string scene){
		yield return StartCoroutine(Fade(Color.clear, Color.black));
		SceneManager.LoadScene(scene);
	}
}
