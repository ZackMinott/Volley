using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {
    [SerializeField] GameObject ballSparklesVFX;
    GameObject[] balls;

	void OnCollisionEnter2D(Collision2D other)
    {
        balls = GameObject.FindGameObjectsWithTag("BeachBall");

        if (other.gameObject.tag == "BeachBall")
        {
            FindObjectOfType<LevelManager>().LoadGameOver();
            for (var i = 0; i < balls.Length; i++)
            {
                GameObject sparkles = Instantiate(ballSparklesVFX, balls[i].transform.position, balls[i].transform.rotation);
                Destroy(sparkles, .7f);
                Destroy(balls[i]);
            }

        }
    }

  

}
