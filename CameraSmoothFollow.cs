using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSmoothFollow : MonoBehaviour
{

    Vector3 offset = new Vector3(0, 0, -10);
    public Transform target;
    public float smoothSpeed = 0.125f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 finalPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, finalPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
