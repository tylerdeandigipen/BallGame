using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyAfterTime : MonoBehaviour
{
    [SerializeField]
    float timeToDestroy = 0;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeToDestroy)
        {
            Destroy(this.gameObject);
        }
    }
}
