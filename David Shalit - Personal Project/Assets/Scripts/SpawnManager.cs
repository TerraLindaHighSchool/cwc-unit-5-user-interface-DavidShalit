using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] prefabs;
    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 2);
    }

    Vector3 randomSpawnPos()
    {
        float x = Random.Range(-13, 13);
        float z = Random.Range(-2, 9);
        return new Vector3(x, 1.0f, z);
    }

    void SpawnObject()
    {
        Instantiate(prefabs[Random.Range(0, prefabs.Length)], randomSpawnPos(), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
