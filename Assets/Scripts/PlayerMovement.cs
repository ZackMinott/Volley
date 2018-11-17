using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //public Transform transform;
    public float speed = 10.0f;
	[HideInInspector] public float screenWidth;
    [HideInInspector] public float spriteWidth;
    Vector3 left;
	Vector3 right;

    public Rigidbody2D rb2d;
    public BoxCollider2D leftWall, rightWall;
	
	//public float screenOffset;

    private void Awake()
    {
		spriteWidth = GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		screenWidth = (Camera.main.orthographicSize * Camera.main.aspect) + spriteWidth /2; //Utilize this to set Ball SPAWN WIDTH, TELEPORT LOCATION, and BAKGROUND WIDTH, and COLLIDER BOUNDARY
        Debug.Log(screenWidth);
		left = new Vector3(-screenWidth, transform.position.y, transform.position.z);
		right = new Vector3(screenWidth, transform.position.y, transform.position.z);
        leftWall.GetComponent<Transform>().position = new Vector3(-screenWidth + spriteWidth / 2, transform.position.y, transform.position.z); 
        rightWall.GetComponent<Transform>().position = new Vector3(screenWidth - spriteWidth / 2, transform.position.y, transform.position.z);
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    void Update()
    {
		
        //NOTE: implement touch feature here
        //var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;

        //transform.Translate(x, 0, 0);

        //Teleport();

    }

    //use this function simply to test within editor
    void FixedUpdate()
    {
#if UNITY_EDITOR
        moveCharacter(Input.GetAxis("Horizontal"));
#endif
    }

    void Teleport()
    {
		if (transform.position.x >= screenWidth)
        {
            transform.position = (left);
        }
		else if (transform.position.x <= -screenWidth)
        {
            transform.position = (right);
        }
    }

    //Will use this to implement addForce to move character instead of translate 
    void moveCharacter(float horizontalInput)
    {
        //move character
        rb2d.velocity = new Vector2(horizontalInput * speed * Time.deltaTime, 0);

        Teleport();
    }
}
