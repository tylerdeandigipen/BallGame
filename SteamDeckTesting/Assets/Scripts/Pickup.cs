using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField]
    float BobSpeed = 1;
    [SerializeField]
    float BobStrength = 2;
    [SerializeField]
    float RotationSpeed = 30;
    float startPos;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        this.transform.position = new Vector3(this.transform.position.x, startPos + (Mathf.Sin(time * BobSpeed) * BobStrength), this.transform.position.z);
        transform.Rotate(0, 1f * Time.deltaTime * RotationSpeed, 0, Space.Self);
    }

}
