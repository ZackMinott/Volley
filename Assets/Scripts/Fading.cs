using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fading : MonoBehaviour {

    public Texture2D fadeOutTexture; //The texture will overlay the screen. This will be a black image or loading graphic.
    public float fadeSpeed = 0.5f; //The fading speed

    private int drawDepth = -1000; //The texture's order in the draw hierarchy: a low number means it renders on top
    private float alpha = 1.0f; //The texture's alpha value between 0 and 1
    private int fadeDir = -1; //The direction to fade : in = -1 or out = 1

    void OnGUI()
    {
        //fade in and out the alpha value using a direction, a speed and Time.deltatime to convert the operation to seconds
        alpha += fadeDir * fadeSpeed * Time.deltaTime;
        //force(clamp) the number between 0 and 1 because GUI.color uses alpha values between 0 and 1
        alpha = Mathf.Clamp01(alpha);
        //set color of GUI (in this case our texture) All color values remain the same & the Alpha is set to the Alpha variable
        GUI.color = new Color(GUI.color.r, GUI.color.g, GUI.color.b, alpha);
        //set the alpha
        GUI.depth = drawDepth;
        //make the black texture render on top(draw last) 
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeOutTexture);
    }

    //sets fadeDir to the Direction parameter making the scene fade in if -1 and out if 1

    public float BeginFade(int direction)
    {
        fadeDir = direction;
        return (fadeSpeed); // return the fadeSpeed variable so it's easy to time the Application.LoadLevel
    }

    //OnLevelWasLoaded() is called when a level is loaded. It takes loaded level index(int) as a parameter so you can limit the fade in certain scenes
    void OnLevelWasLoaded()
    {
        //alpha = -1            //use this if alpha is not set to by default
        BeginFade(-1); //call the fade in function
    }

}
