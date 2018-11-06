using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {

    [SerializeField]
    private int hitCount = 0; 
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BeachBall")
        {
            hitCount += 1;
        } 

        if(hitCount >= 6)
        {
            Destroy(this.gameObject);
        }
    }
}
