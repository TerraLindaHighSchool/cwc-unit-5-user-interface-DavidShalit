using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 4.5f;
    private Rigidbody enemyRb;
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //transform.Translate(0, 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward / -speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Bounds")
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.tag == "Player")
        {

        }
    }
}
