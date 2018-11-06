using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAspectRatio : MonoBehaviour {

	public float targetAspect;

	void Start () 
	{
		float windowAspect = (float)Screen.width / (float)Screen.height;
		float scaleHeight = windowAspect / targetAspect;
		Camera camera = GetComponent<Camera>();

		if (scaleHeight < 1.0f)
		{  
			camera.orthographicSize = camera.orthographicSize / scaleHeight;
		}
	}
}
