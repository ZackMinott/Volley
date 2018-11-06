using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBall : MonoBehaviour {
    public GameObject beachBallPrefab; //Get instance of beach ball
    public float y;
    public float forceApplied = 550.0f;

    private float x;
    private ScoreTracker scoreTracker;
    private bool spawn = true; //allows a ball to spawn right away
    

    void Start()
    {
        scoreTracker = GameObject.Find("GameController").GetComponent<ScoreTracker>();

        x = GetComponent<PlayerMovement>().screenWidth - (GetComponent<PlayerMovement>().spriteWidth + beachBallPrefab.GetComponent<SpriteRenderer>().sprite.bounds.size.x / 2);

        spawnBall();
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
        }
    }

    
    void SpawnCheck()
    {
        if (scoreTracker.score % 5 == 0)
        {
            spawnBall();
        }
    }

    void spawnBall()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-x, x), y, -1);

        Instantiate(beachBallPrefab, spawnPos, Quaternion.identity);
        Debug.Log("Ball Spawned");
    }
}
