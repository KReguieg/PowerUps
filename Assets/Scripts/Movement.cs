using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    [SerializeField]
    [Range(0.0f, 1.0f)]
    private float speed;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            transform.position += Vector3.up * speed;
        }
    }
}
