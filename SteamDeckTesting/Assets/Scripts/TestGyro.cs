using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestGyro : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
            Input.gyro.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = GyroToRotation(Input.gyro.attitude);
    }

    private Quaternion GyroToRotation(Quaternion q)
    {
        return new Quaternion(q.x, q.y, -q.z, -q.w);
    }
}
