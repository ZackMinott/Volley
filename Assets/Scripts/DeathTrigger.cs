using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathTrigger : MonoBehaviour {
    [SerializeField] GameObject ballSparklesVFX;
    [SerializeField] AudioClip[] ballDeathSounds;
    //[SerializeField] private AudioClip deathSound;
    GameObject[] balls;
    private AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void OnCollisionEnter2D(Collision2D other)
    {
        balls = GameObject.FindGameObjectsWithTag("BeachBall");

        if (other.gameObject.tag == "BeachBall")
        {
            FindObjectOfType<LevelManager>().LoadGameOver();
            //audioSource.PlayOneShot(deathSound, .8f);
            for (var i = 0; i < balls.Length; i++)
            {
                AudioClip clip = ballDeathSounds[UnityEngine.Random.Range(0, ballDeathSounds.Length)];
                audioSource.PlayOneShot(clip, 1f);
                GameObject sparkles = Instantiate(ballSparklesVFX, balls[i].transform.position, balls[i].transform.rotation);
                Destroy(sparkles, .7f);
                Destroy(balls[i]);
            }

        }
    }

  

}
