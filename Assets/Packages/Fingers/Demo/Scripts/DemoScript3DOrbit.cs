using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigitalRubyShared
{
	public class DemoScript3DOrbit : MonoBehaviour
	{
		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			}
		}
	}
}
