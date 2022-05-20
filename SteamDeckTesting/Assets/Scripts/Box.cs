using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    bool hasBeenHit = false;
    ScoreManager scoreCounter;
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && !hasBeenHit)
        { 
            hasBeenHit = true;
            scoreCounter.blocksHit += 1;
        }
    }
}
