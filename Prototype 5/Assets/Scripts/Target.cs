using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody targetRb;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(6, 12), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-4, 4), 6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
