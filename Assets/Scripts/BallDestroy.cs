using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDestroy : MonoBehaviour {

    [SerializeField]
    private int hitCount = 0;
    [SerializeField] GameObject ballSparklesVFX;
    [SerializeField] AudioClip[] ballDeathSounds;

    private AudioSource myAudioSource;

    void OnCollisionEnter2D(Collision2D col)
    {
        myAudioSource = GetComponent<AudioSource>();

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
        AudioClip clip = ballDeathSounds[UnityEngine.Random.Range(0, ballDeathSounds.Length)];
        myAudioSource.PlayOneShot(clip);
        GameObject sparkles = Instantiate(ballSparklesVFX, transform.position, transform.rotation);
        Destroy(sparkles, .7f);
    }

    
}
