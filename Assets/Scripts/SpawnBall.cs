using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {
    public GameObject beachBallPrefab; //Get instance of beach ball
    public AudioClip hitSound;

    public float y;
    public float forceApplied = 550.0f;
    public float ballVelocity = 15.0f;

    private float x;
    private ScoreTracker scoreTracker;
    private bool spawn = true; //allows a ball to spawn right away

    GameObject[] ballsInstantiated;

    void Start()
    {
        scoreTracker = GameObject.Find("GameController").GetComponent<ScoreTracker>();

        x = GetComponent<PlayerMovement>().screenWidth - (GetComponent<PlayerMovement>().spriteWidth + beachBallPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2);

        spawnBall();
    }

    private void LateUpdate()
    {

        ballsInstantiated = GameObject.FindGameObjectsWithTag("BeachBall");
        foreach (GameObject beachBall in ballsInstantiated)
        {
            var vel = beachBall.GetComponent<Rigidbody2D>().velocity;
            beachBall.GetComponent<Rigidbody2D>().velocity = ballVelocity * vel.normalized;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "BeachBall")
        {
            scoreTracker.AddScore();
            Debug.Log(scoreTracker.score);
            SpawnCheck();

            //add force to beach ball
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * forceApplied);
            GetComponent<AudioSource>().PlayOneShot(hitSound, 0.7f);
        }
    }

    
    void SpawnCheck()
    {
        if (scoreTracker.score % 3 == 0)
        {
            spawnBall();
        }
    }

    void spawnBall()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-x, x), y, -1);

        GameObject obj = Instantiate(beachBallPrefab, spawnPos, Quaternion.identity);
        obj.GetComponent<Rigidbody2D>().velocity = transform.up * -ballVelocity; 
        Debug.Log("Ball Spawned");
    }
}
