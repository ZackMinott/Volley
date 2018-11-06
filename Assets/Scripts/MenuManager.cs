using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour {
    /*
     * This Script is used for opening up menu canvases
     */

	public void OpenCanvas(GameObject menuCanvas)
    {
        menuCanvas.SetActive(true);
    }

    public void CloseCanvas(GameObject menuCanvas)
    {
        menuCanvas.SetActive(false);
    }
}
