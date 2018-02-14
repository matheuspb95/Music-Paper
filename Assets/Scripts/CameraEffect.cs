using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class CameraEffect : MonoBehaviour {
	public Transform player;
	public float intensity;
	private Material material;
	public Shader shader;

	// Creates a private material used to the effect
	void Awake ()
	{
		material = new Material(shader);
	}

	void Update(){
		intensity = (player.position.y) * 0.1f;
		if(intensity < -1) intensity = -1;
	}
	
	// Postprocess the image
	void OnRenderImage (RenderTexture source, RenderTexture destination)
	{
		if (intensity == 0)
		{
			Graphics.Blit (source, destination);
			return;
		}

		material.SetFloat("_Saturate", intensity);
		Graphics.Blit (source, destination, material);
	}
}
