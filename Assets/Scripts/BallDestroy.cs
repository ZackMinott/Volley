using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {

    [SerializeField]
    private int hitCount = 0;
    [SerializeField] GameObject ballSparklesVFX;
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "BeachBall")
        {
            hitCount += 1;
        } 

        if(hitCount >= 10)
        {
            TriggerParticleVFX();
            Destroy(this.gameObject);
        }
    }

    void TriggerParticleVFX()
    {
        GameObject sparkles = Instantiate(ballSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, .7f);
    }
}
