using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharScript : MonoBehaviour
{
    [SerializeField]
    float strength = 1;
    [SerializeField]
    float speed = 1;

    bool hasBeenHit = false;
    ScoreManager scoreCounter;
    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y + (Mathf.Sin(Time.deltaTime * speed) * strength), transform.position.z);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            scoreCounter.collectablesGot += 1;
        }
    }
}
